import requests
import json
from getpass import getpass
from datetime import datetime, timedelta

"""
Make sure to set a valid nodeID in line 50 before using!
"""

class SwisClient:
	def __init__(self, hostname, username, password):
		self.url = "https://%s:17778/SolarWinds/InformationService/v3/Json/" % (hostname)
		self.credentials = (username, password)

	def query(self, query, **params):
		return self._req("POST", "Query", {'query': query, 'parameters': params}).json()

	def invoke(self, entity, verb, *args):
		return self._req("POST", "Invoke/%s/%s" % (entity, verb), args).json()

	def create(self, entity, **properties):
		return self._req("POST", "Create/" + entity, properties).json()

	def read(self, uri):
		return self._req("GET", uri).json()

	def update(self, uri, **properties):
		self._req("POST", uri, properties)

	def delete(self, uri):
		self._req("DELETE", uri)

	def _json_serial(obj):
		"""JSON serializer for objects not serializable by default json code"""

		if isinstance(obj, datetime):
			serial = obj.isoformat()
			return serial

	def _req(self, method, frag, data=None):
		return requests.request(method, self.url + frag, 
			data=json.dumps(data, default=SwisClient._json_serial), 
			verify=False, 
			auth=self.credentials, 
			headers={'Content-Type': 'application/json'})

requests.packages.urllib3.disable_warnings()

def samplecode(npm_server,username,password):
	swis = SwisClient(npm_server,username,password)
	
	print ("Invoke Test:")
	aliases = swis.invoke("Metadata.Entity", "GetAliases", "SELECT B.Caption FROM Orion.Nodes B")
	print (aliases)

	print ("Query Test:")
	results = swis.query("SELECT Uri FROM Orion.Nodes WHERE NodeID=@id", id=104) # set valid NodeID!
	uri = results['results'][0]['Uri']
	print (uri)

	print ("Custom Property Update Test:")
	swis.update(uri + "/CustomProperties", city="Austin")
	obj = swis.read(uri + "/CustomProperties")
	print (obj)

	pollerUri = swis.create("Orion.Pollers", PollerType="just testing", 
		NetObject="N:" + str(obj["NodeID"]), NetObjectType="N", NetObjectID=obj["NodeID"])
	print (pollerUri)

	print ("Deleting temporary poller....")
	swis.delete(pollerUri)

def unmanage_an_interface():
	swis = SwisClient("localhost", "admin", "")
	results = swis.query("SELECT TOP 1 NodeID FROM Orion.Nodes")
	interfaceId = results["results"][0]["NodeID"]
	netObjectId = "N:{}".format(interfaceId)
	now = datetime.utcnow()
	tomorrow = now + timedelta(days=1)
	swis.invoke("Orion.Nodes", "Unmanage", netObjectId, now, tomorrow, False)

def main():
	#try: input = raw_input  # Fix Python 2.x
	npm_server = input("IP address of NPM Server: ")
	username = input("Username: ")
	password = getpass("Password: ")

	samplecode(npm_server,username,password)


if __name__ == "__main__":
	#main()
	unmanage_an_interface()

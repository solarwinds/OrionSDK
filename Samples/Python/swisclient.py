import requests
import json
from datetime import datetime


def _json_serial(obj):
    """JSON serializer for objects not serializable by default json code"""
    if isinstance(obj, datetime):
        serial = obj.isoformat()
        return serial


class SwisClient:
    def __init__(self, hostname, username, password):
        self.url = "https://{}:17778/SolarWinds/InformationService/v3/Json/".\
                format(hostname)
        self.credentials = (username, password)

    def query(self, query, **params):
        return self._req(
                "POST",
                "Query",
                {'query': query, 'parameters': params}).json()

    def invoke(self, entity, verb, *args):
        return self._req(
                "POST",
                "Invoke/{}/{}".format(entity, verb), args).json()

    def create(self, entity, **properties):
        return self._req(
                "POST",
                "Create/" + entity, properties).json()

    def read(self, uri):
        return self._req("GET", uri).json()

    def update(self, uri, **properties):
        self._req("POST", uri, properties)

    def delete(self, uri):
        self._req("DELETE", uri)

    def _req(self, method, frag, data=None):
        return requests.request(method, self.url + frag,
                                data=json.dumps(data, default=_json_serial),
                                verify=False,
                                auth=self.credentials,
                                headers={'Content-Type': 'application/json'})


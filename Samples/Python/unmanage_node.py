import requests
import swisclient
from datetime import datetime, timedelta


def main():
    hostname = 'localhost'
    username = 'admin'
    password = ''

    swis = swisclient.SwisClient(hostname, username, password)
    results = swis.query('SELECT TOP 1 NodeID FROM Orion.Nodes')
    interfaceId = results['results'][0]['NodeID']
    netObjectId = 'N:{}'.format(interfaceId)
    now = datetime.utcnow()
    tomorrow = now + timedelta(days=1)
    swis.invoke('Orion.Nodes', 'Unmanage', netObjectId, now, tomorrow, False)


requests.packages.urllib3.disable_warnings()


if __name__ == '__main__':
    main()

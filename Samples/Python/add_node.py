import re
import requests
import swisclient


def main():
    npm_server = 'localhost'
    username = 'admin'
    password = ''

    swis = swisclient.SwisClient(npm_server, username, password)
    print("Add an SNMP v2c node:")
  
    # fill these in for the node you want to add!
    node_name = ''
    ip_address = ''
    community = ''

    # set up property bag for the new node
    props = {
        'Caption': node_name,
        'IPAddress': ip_address,
        'DynamicIP': False,
        'EngineID': 1,
        'Status': 1,
        'Allow64BitCounters': 1,
        'ObjectSubType': 'SNMP',
        'SNMPVersion': 2,
        'SysObjectID': '',
        'MachineType': '',
        'Vendor': '',
        'VendorIcon': '',
        'RediscoveryInterval': 30,
        'PollInterval': 120,
        'ChildStatus': 1,
        'StatCollection': 10,
        'Community': community,
        'NodeDescription': '',
    }

    print("Adding node {}... ".format(props['IPAddress']), end="")
    results = swis.create('Orion.Nodes', **props)
    print("DONE!")

    # extract the nodeID from the result
    nodeid = re.search('(\d+)$', results).group(0)

    pollers_enabled = {
        'N.Status.ICMP.Native': True,
        'N.Status.SNMP.Native': False,
        'N.ResponseTime.ICMP.Native': True,
        'N.ResponseTime.SNMP.Native': False,
        'N.Details.SNMP.Generic': True,
        'N.Uptime.SNMP.Generic': True,
        'N.Cpu.SNMP.HrProcessorLoad': True,
        'N.Memory.SNMP.NetSnmpReal': True,
        'N.AssetInventory.Snmp.Generic': True,
        'N.Status.SNMP.Native': False,
        'N.ResponseTime.SNMP.Native': False,
        'N.Topology_Layer3.SNMP.ipNetToMedia': False,
        'N.Routing.SNMP.Ipv4CidrRoutingTable': False
    }

    pollers = []
    for k in pollers_enabled:
        pollers.append(
            {
                'PollerType': k,
                'NetObject': 'N:' + nodeid,
                'NetObjectType': 'N',
                'NetObjectID': nodeid,
                'Enabled': pollers_enabled[k]
            }
        )

    for poller in pollers:
        print("  Adding poller type: {} with status {}... ".\
              format(poller['PollerType'],
                     poller['Enabled']),
              end="")
        response = swis.create('Orion.Pollers', **poller)
        print("DONE!")


requests.packages.urllib3.disable_warnings()


if __name__ == '__main__':
    main()


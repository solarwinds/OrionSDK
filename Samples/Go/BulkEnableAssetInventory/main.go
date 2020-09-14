package main

import (
	"github.com/mrxinu/gosolar"

	log "github.com/sirupsen/logrus"
)

func main() {
	// SolarWinds connection parameters
	hostname := "localhost"
	username := "admin"
	password := ""

	// connect to solarwinds
	swClient := gosolar.NewClient(hostname, username, password, true)

	// select what nodes to enable asset inventory polling on
	// based on IP Address
	ipAddresses := []string{
		"192.0.2.0",
		"192.0.2.1",
		"192.0.2.2",
	}

	// get the node IDs
	query := `SELECT NodeID FROM Orion.Nodes WHERE IPAddress IN @ipaddresses`

	parameters := map[string]interface{}{
		"ipaddresses": ipAddresses,
	}

	nodeIDs, err := swClient.QueryColumn(query, parameters)
	if err != nil {
		log.Fatal(err)
	}

	// set verb argument values
	args := []interface{}{
		nodeIDs,
	}

	// invoke 'EnablePollingForNodes'
	resp, err := swClient.Invoke("Orion.AssetInventory.Polling", "EnablePollingForNodes", args)
	if err != nil {
		log.Fatal(err)
	}

	// a response of 'true' means asset inventory polling was enabled immediately
	// a response of 'false' means Orion doesn't have discovery information and a
	// background mechanism started to collect it, it will take some time for this
	// to finish and the asset inventory polling to show as 'enabled'
	log.Info(string(resp))
}

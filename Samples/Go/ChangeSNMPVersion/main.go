package main

import (
	"encoding/json"
	"fmt"
	"log"

	"github.com/mrxinu/gosolar"
)

// Node struct holds query results
type Node struct {
	URI string `json:"uri"`
}

func main() {
	// SolarWinds connection details
	hostname := "localhost"
	username := "admin"
	password := ""

	// connect to SolarWinds
	client := gosolar.NewClient(hostname, username, password, true)

	// query for node uri
	query := `SELECT Uri
	FROM Orion.Nodes
	WHERE IPAddress = '192.0.2.0'`

	res, err := client.Query(query, nil)
	if err != nil {
		log.Fatal(err)
	}

	var nodes []*Node
	if err := json.Unmarshal(res, &nodes); err != nil {
		log.Fatal(err)
	}

	// change to snmp v3
	req := map[string]interface{}{
		"SNMPVersion":      3,
		"SNMPV3Username":   "",
		"SNMPV3Context":    "",
		"SNMPV3PrivMethod": "", // None, DES56, AES128, AES 192, AES256
		"SNMPV3PrivKey":    "",
		"SNMPV3AuthMethod": "", // None, MD5, SHA1
		"SNMPV3AuthKey":    "",
	}

	_, err = client.Update(nodes[0].URI, req)
	if err != nil {
		fmt.Println(fmt.Sprintf("failed to update node: %v", err))
	}
}

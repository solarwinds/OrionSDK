package main

import (
	"encoding/json"
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
	FROM Cirrus.Nodes
	WHERE AgentIP = '192.0.2.0'`

	res, err := client.Query(query, nil)
	if err != nil {
		log.Fatal(err)
	}

	var nodes []*Node
	if err := json.Unmarshal(res, &nodes); err != nil {
		log.Fatal(err)
	}

	// properties
	req := map[string]interface{}{
		"ConnectionProfile": 1,
	}

	_, err = client.Update(nodes[0].URI, req)
	if err != nil {
		log.Fatal(err)
	}
}

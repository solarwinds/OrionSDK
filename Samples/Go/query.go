package main

import (
	"encoding/json"
	"fmt"
	"log"

	"github.com/mrxinu/gosolar"
)

func main() {
	// define your connection parameters
	hostname := "localhost"
	username := "admin"
	password := ""

	// create a new gosolar client
	c := gosolar.NewClient(hostname, username, password, true)

	// query for the caption and get IP address for each node
	res, err := c.Query("SELECT Caption, IPAddress FROM Orion.Nodes", nil)
	if err != nil {
		log.Fatal(err)
	}

	// create struct slice for the nodes
	nodes := []struct {
		NodeName  string `json:"caption"`
		IPAddress string `json:"ipaddress"`
	}{}

	// convert the JSON response
	if err := json.Unmarshal(res, &nodes); err != nil {
		log.Fatal(err)
	}

	// iterate over the nodes and display the information
	for _, n := range nodes {
		fmt.Printf("Device name: %v, IP Address: %v\n", n.NodeName, n.IPAddress)
	}
}

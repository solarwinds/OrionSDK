package main

import (
	"encoding/json"
	"fmt"
	"log"

	"github.com/mrxinu/gosolar"
)

func main() {
	var err error

	// define your connection parameters
	hostname := "localhost"
	username := ""
	password := ""

	// create a new gosolar client
	c := gosolar.NewClient(hostname, username, password, true)

	// get the first URI from the Orion.Nodes entity
	var res []byte
	res, err = c.Query("SELECT TOP 1 URI FROM Orion.Nodes", nil)
	if err != nil {
		log.Fatal(err)
	}

	// create a structure to hold the results
	var nodes []struct {
		URI string
	}

	// convert the results from JSON
	if err = json.Unmarshal(res, &nodes); err != nil {
		log.Fatal(err)
	}

	// get the single URI from the first return
	singleURI := nodes[0].URI

	var nodeData []byte
	nodeData, err = c.Read(singleURI)
	if err != nil {
		log.Fatal(err)
	}

	// create a structure with as much of the node data as you need
	var nodeDetail struct {
		Caption     string
		Vendor      string
		MachineType string
		Status      int
	}

	// convert the results from JSON
	if err := json.Unmarshal(nodeData, &nodeDetail); err != nil {
		log.Fatal(err)
	}

	// print the results
	fmt.Printf("Caption: %v\n", nodeDetail.Caption)
	fmt.Printf("Vendor: %v\n", nodeDetail.Vendor)
	fmt.Printf("MachineType: %v\n", nodeDetail.MachineType)
	fmt.Printf("Status: %v\n", nodeDetail.Status)
}

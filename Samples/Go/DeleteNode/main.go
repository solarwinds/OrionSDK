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

	// create a map of interface for the parameters
	parameters := map[string]interface{}{
		"id": 1,
	}

	// query for the URI of the node you want to delete
	res, err := c.Query(`SELECT Uri FROM Orion.Nodes WHERE NodeID = @id`, parameters)
	if err != nil {
		log.Fatal(err)
	}

	// create struct slice for the node
	var nodes []struct {
		URI string `json:"Uri"`
	}

	if err := json.Unmarshal(res, &nodes); err != nil {
		log.Fatal(err)
	}

	fmt.Printf("I'm going to delete the node at: %s", nodes[0].URI)

	// delete the node with the selected URI
	_, err = c.Delete(nodes[0].URI)
	if err != nil {
		log.Fatal(err)
	}
}

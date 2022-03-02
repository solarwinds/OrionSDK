package main

import (
	"encoding/json"
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

	// query for the URI of the selected node
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

	// update the property city for the selected node
	if err = c.SetCustomProperty(nodes[0].URI, "City", "Los Angeles"); err != nil {
		log.Fatal(err)
	}
}

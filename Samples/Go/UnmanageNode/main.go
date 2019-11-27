package main

import (
	"encoding/json"
	"fmt"
	"log"
	"time"

	"github.com/mrxinu/gosolar"
	"github.com/pkg/errors"
)

var c *gosolar.Client

// Node details
type Node struct {
	NodeID  int    `json:"nodeid"`
	Caption string `json:"caption"`
}

func main() {
	// define your connection parameters
	hostname := "localhost"
	username := "admin"
	password := ""

	// create a new gosolar client
	c = gosolar.NewClient(hostname, username, password, true)

	nodes, err := getNodes()
	if err != nil {
		log.Fatal(err)
	}

	// set parameters for unmanaging the node
	now := time.Now()
	nowUTC := now.UTC()
	laterUTC := nowUTC.Add(time.Hour * 48)

	for _, n := range nodes {
		fmt.Printf("Working with node named %s\n", n.Caption)

		// create a struct slice for the request
		properties := []interface{}{
			fmt.Sprintf("N:%d", n.NodeID),
			nowUTC,
			laterUTC,
			false,
		}

		// invoke the verb for the request
		_, err := c.Invoke("Orion.Nodes", "Unmanage", properties)
		if err != nil {
			log.Fatal(err)
		}

		fmt.Printf("Unmanaged node %s\n", n.Caption)
	}
}

func getNodes() ([]Node, error) {
	// query for the ID and caption of the selected node
	query := `
		SELECT
			Nodes.NodeID
			,Nodes.Caption
		FROM Orion.Nodes AS Nodes
		WHERE Nodes.NodeID = 1
	`

	res, err := c.Query(query, nil)
	if err != nil {
		return nil, errors.Wrap(err, "failed to query")
	}

	var nodes []Node
	if err := json.Unmarshal(res, &nodes); err != nil {
		return nil, errors.Wrap(err, "failed to unmarshal")
	}

	return nodes, nil
}

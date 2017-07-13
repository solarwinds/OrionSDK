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

	// you would get these using SWQL queries, but we'll set them statically
	// as an example
	parentID := 1
	parentURI := "swis://example.com/Orion/Orion.Nodes/NodeID=1"
	parentType := "Orion.Nodes"

	childID := 4
	childURI := "swis://example.com/Orion/Orion.Nodes/NodeID=4"
	childType := "Orion.Nodes"

	req := map[string]interface{}{
		"Name":              "Sample Dependency",
		"ParentUri":         parentURI,
		"ChildUri":          childURI,
		"ParentEntityType":  parentType,
		"ChildEntityType":   childType,
		"ParentNetObjectID": parentID,
		"ChildNetObjectID":  childID,
	}

	res, err := c.Create("Orion.Dependencies", req)
	if err != nil {
		log.Fatal(err)
	}

	var dependencyURI string
	if err := json.Unmarshal(res, &dependencyURI); err != nil {
		log.Fatal(err)
	}

	fmt.Printf("Created dependency with URI: %s\n", dependencyURI)
}

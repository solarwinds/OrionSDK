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

	var members []map[string]string

	members = append(members, map[string]string{
		"Name":       "Windows Devices",
		"Definition": "filter:/Orion.Nodes[Vendor='Windows']",
	})

	members = append(members, map[string]string{
		"Name":       "Cisco Devices",
		"Definition": "filter:/Orion.Nodes[Vendor='Cisco']",
	})

	req := []interface{}{
		"Sample Group",
		"Core",
		60,
		0,
		"Group created by Go sample program.",
		true,
		members,
	}

	var containerID int
	res, err := c.Invoke("Orion.Container", "CreateContainer", req)
	if err != nil {
		log.Fatal(err)
	}

	if err := json.Unmarshal(res, &containerID); err != nil {
		log.Fatal(err)
	}

	fmt.Printf("Created new group with the ID: %d\n", containerID)
}

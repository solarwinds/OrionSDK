package main

import (
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

	// query for the URIs for the top 3 nodes
	values, err := c.QueryColumn(`SELECT TOP 3 URI FROM Orion.Nodes `, nil)
	if err != nil {
		log.Fatal(err)
	}

	// build a slice of strings for the URIs returned from the query
	uris := make([]string, len(values))
	for i, v := range values {
		uris[i] = v.(string)
	}

	if err := c.BulkSetCustomProperty(uris, "City", "Los Angeles"); err != nil {
		log.Fatal(err)
	}
}

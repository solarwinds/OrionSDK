package main

import (
	"encoding/json"
	"fmt"
	"log"
	"os"

	"github.com/mrxinu/gosolar"
)

func main() {
	// define your connection parameters
	hostname := "localhost"
	username := "admin"
	password := ""

	// create a new gosolar client
	c := gosolar.NewClient(hostname, username, password, true)

	res, err := c.Query("SELECT TOP 1 AlertObjectID FROM Orion.AlertActive ORDER BY TriggeredDateTime DESC", nil)
	if err != nil {
		log.Fatal(err)
	}

	var nodes []struct {
		AlertObjectID int `json:"AlertObjectID"`
	}

	if err := json.Unmarshal(res, &nodes); err != nil {
		log.Fatal(err)
	}

	// check the result for values
	if len(nodes) <= 0 {
		fmt.Fprintln(os.Stderr, "No rows returned, exiting.")
		os.Exit(1)
	}

	// create a struct slice for the request
	req := []interface{}{
		[]int{nodes[0].AlertObjectID},
		"This is the note to send to the alert",
	}

	// invoke the verb for the request
	_, err = c.Invoke("Orion.AlertActive", "AppendNote", req)
	if err != nil {
		log.Fatal(err)
	}
}

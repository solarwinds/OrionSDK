package main

import (
	"encoding/json"
	"gosolar"
	"log"

	"github.com/pkg/errors"
)

// Group holds details about the SolarWinds Orion container.
type Group struct {
	ID               int32  `json:"ID"`
	Name             string `json:"Name"`
	Owner            string `json:"Owner"`
	Frequency        int32  `json:"Frequency"`
	StatusCalculator int16  `json:"StatusCalculator"`
	Description      string `json:"Description"`
	PollingEnabled   bool   `json:"PollingEnabled"`
}

func main() {
	// define your connection parameters
	hostname := "localhost"
	username := "admin"
	password := ""

	// create a new gosolar client
	client := gosolar.NewClient(hostname, username, password, true)

	// get the required details about that group first
	group, err := getGroupByName(client, "Serenity Group")
	if err != nil {
		log.Fatal(err)
	}

	// provide those details to the UpdateContainer verb with either the same
	// information from the group as it is, or the changes you want
	arguments := []interface{}{
		group.ID,
		group.Name,
		group.Owner,
		group.Frequency,
		group.StatusCalculator,
		"My new description goes here.",
		group.PollingEnabled,
	}

	if _, err := client.Invoke("Orion.Container", "UpdateContainer", arguments); err != nil {
		log.Fatal(err)
	}
}

func getGroupByName(client *gosolar.Client, name string) (*Group, error) {

	query := `
		SELECT
			Container.ContainerID AS ID
			, Container.Name AS Name
			, Container.Owner AS Owner
			, Container.Frequency AS Frequency
			, Container.statusCalculator AS StatusCalculator
			, Container.Description AS Description
			, Container.pollingEnabled AS PollingEnabled
		FROM Orion.Container AS Container
		WHERE Container.Name = @containerName
	`

	parameters := map[string]interface{}{
		"containerName": "Serenity Group",
	}

	row, err := client.QueryRow(query, parameters)
	if err != nil {
		return nil, errors.Wrap(err, "failed to query")
	}

	var container *Group
	if err := json.Unmarshal(row, &container); err != nil {
		return nil, errors.Wrap(err, "failed to unmarshal")
	}

	return container, nil
}

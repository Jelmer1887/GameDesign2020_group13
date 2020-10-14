using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{

	public GameObject[] players;
	int currentPlayer = 0;

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			switchPlayer();
		}
    }

	//Cycle through players by deactivating active player and activating next player
	private void switchPlayer() {
		//Switch off current player
		players[currentPlayer].transform.Find("Camera").GetComponent<Camera>().enabled = false;
		players[currentPlayer].GetComponent<PlayerMovement>().enabled = false;
		players[currentPlayer].GetComponent<PlayerLookAround>().enabled = false;
		if(players[currentPlayer].GetComponent<PlayerDisguise>() != null) {
			players[currentPlayer].GetComponent<PlayerDisguise>().enabled = false;
		}

		currentPlayer++;
		if(currentPlayer == players.Length) {
			currentPlayer = 0;
		}

		//Switch on next player
		players[currentPlayer].transform.Find("Camera").GetComponent<Camera>().enabled = true;
		players[currentPlayer].GetComponent<PlayerMovement>().enabled = true;
		players[currentPlayer].GetComponent<PlayerLookAround>().enabled = true;
		if (players[currentPlayer].GetComponent<PlayerDisguise>() != null) {
			players[currentPlayer].GetComponent<PlayerDisguise>().enabled = true;
		}
	}
}

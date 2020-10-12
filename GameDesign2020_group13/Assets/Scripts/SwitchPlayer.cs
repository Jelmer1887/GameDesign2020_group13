using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{

	public GameObject[] players;
	int currentPlayer = 0;

    void Update() {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			switchPlayer();
		}
    }

	void switchPlayer() {
		//switch off current player
		players[currentPlayer].transform.Find("Camera").GetComponent<Camera>().enabled = false;
		players[currentPlayer].transform.GetComponent<PlayerMovement>().enabled = false;
		players[currentPlayer].transform.GetComponent<PlayerLookAround>().enabled = false;

		currentPlayer++;
		if(currentPlayer == players.Length) {
			currentPlayer = 0;
		}

		//switch on next player
		players[currentPlayer].transform.Find("Camera").GetComponent<Camera>().enabled = true;
		players[currentPlayer].transform.GetComponent<PlayerMovement>().enabled = true;
		players[currentPlayer].transform.GetComponent<PlayerLookAround>().enabled = true;
	}
}

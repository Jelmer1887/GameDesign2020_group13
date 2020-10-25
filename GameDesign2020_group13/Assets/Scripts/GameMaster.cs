using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
	//Singleton, makes sure there is always one gamemaster instance
	private static GameMaster _instance;
	public static GameMaster Instance { get { return _instance; } }

	private void Awake() {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
	}

	public Transform[] spawnpoints;
	public int keys;
	public static int lives = 3;

	public GameObject[] players;
	public int currentPlayer = 0;

	private void Start() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		lives = 3;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			switchPlayer();
		}
	}

	//Respawns the player at current spawnpoint
	public void respawnPlayer(GameObject player) {
		int playerInd = Array.IndexOf(players, player);
		if (playerInd != -1) {
			players[playerInd].transform.position = spawnpoints[playerInd].position;
			players[playerInd].transform.rotation = spawnpoints[playerInd].rotation;
		}
	}

	//Moves the game to the next level
	public void nextLevel() {
		if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		} else {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			SceneManager.LoadScene(0);
		}
	}

	//Adds a key
	public void pickupKey() {
		Debug.Log("Picked up a key!");
		keys++;
	}

	//Uses a key if there is one
	//Reports to the script that called this method
	//whether it was successful or not
	public bool useKey() {
		if(keys > 0) {
			keys--;
			return true;
		} else {
			return false;
		}
	}

	//Removes a life
	//If there are no lifes left, restart the level
	public void removeLife() {
		lives--;

		if (lives == 0) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	//Cycle through players by deactivating active player and activating next player
	private void switchPlayer() {
		//Switch off current player
		players[currentPlayer].transform.Find("CM").GetComponent<CinemachineFreeLook>().enabled = false;
		players[currentPlayer].GetComponent<PlayerMovement>().enabled = false;
		if (players[currentPlayer].GetComponent<PlayerDisguise>() != null) {
			players[currentPlayer].GetComponent<PlayerDisguise>().enabled = false;
		}

		currentPlayer++;
		if (currentPlayer == players.Length) {
			currentPlayer = 0;
		}

		//Switch on next player
		players[currentPlayer].transform.Find("CM").GetComponent<CinemachineFreeLook>().enabled = true;
		players[currentPlayer].GetComponent<PlayerMovement>().enabled = true;
		if (players[currentPlayer].GetComponent<PlayerDisguise>() != null) {
			players[currentPlayer].GetComponent<PlayerDisguise>().enabled = true;
		}
	}
}

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

	public Transform spawnpoint;
	public int keys;

	//Respawns the player at current spawnpoint
	public void respawnPlayer(GameObject player) {
		player.transform.position = spawnpoint.position;
		player.transform.rotation = spawnpoint.rotation;
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
}

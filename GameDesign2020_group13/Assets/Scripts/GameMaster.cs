using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public GameObject player;

	void Update(){

        if(player == null) {
			player = GameObject.FindGameObjectWithTag("Player");
		}
    }

	//Respawns the player at current spawnpoint
	public void respawnPlayer() {
		player.transform.position = spawnpoint.position;
		player.transform.rotation = spawnpoint.rotation;
	}

	//Moves the game to the next level
	public void nextLevel() {
		Debug.Log("Next Level");
	}
}

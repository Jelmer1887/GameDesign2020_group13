using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour{

	//If this is touched by the player, let the gamemaster respawn the player
	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("DisguisedPlayer")) {
			GameMaster.Instance.removeLife();
			GameMaster.Instance.respawnPlayer(collision.gameObject);
		}
	}
}

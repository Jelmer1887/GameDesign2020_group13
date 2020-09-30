using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour{

	//If this is touched by the player, let the gamemaster get us to the next level
	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Player")) {
			GameMaster.Instance.nextLevel();
		}
	}
}

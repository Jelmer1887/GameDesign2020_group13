using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour{

	public GameObject audioHolder;
	public AudioClip finishSound;
	private int playerCount;

	//If this is touched by the player, let the gamemaster get us to the next level
	private void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("DisguisedPlayer")) {
			playerCount++;

			if (playerCount >= 3) {
				GameObject newAudio = Instantiate(audioHolder, transform.position, Quaternion.identity);
				newAudio.GetComponent<AudioSource>().PlayOneShot(finishSound, 0.3f);
				GameMaster.Instance.nextLevel();
			}
		}
	}

	private void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("DisguisedPlayer")) {
			playerCount--;
		}
	}
}

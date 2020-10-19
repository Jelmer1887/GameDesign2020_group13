using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour{

	public GameObject audioHolder;
	public AudioClip finishSound;

	//If this is touched by the player, let the gamemaster get us to the next level
	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Player")) {
			GameObject newAudio = Instantiate(audioHolder, transform.position, Quaternion.identity);
			newAudio.GetComponent<AudioSource>().PlayOneShot(finishSound, 0.3f);
			GameMaster.Instance.nextLevel();
		}
	}
}

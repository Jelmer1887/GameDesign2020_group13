using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour{

	public float rotationSpeed = 3f;

	//Rotates the key on the y-axis
	private void Update() {
		this.transform.Rotate(0, rotationSpeed, 0f);
	}

	//If a player walks against the key, 
	//the player has one more key and this gameobject is destroyed
	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Player")) {
			GameMaster.Instance.pickupKey();
			Destroy(this.gameObject);
		}
	}
}

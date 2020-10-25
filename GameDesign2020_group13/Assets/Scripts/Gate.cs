using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
	public GameObject gateClosed;
	public GameObject gateOpen;
	private bool hasOpened;

	//Closes the gate
	private void Start() {
		gateClosed.SetActive(true);
		gateOpen.SetActive(false);
	}

	//If the player walks against the closed gate with enough keys, it opens
	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("DisguisedPlayer")) {
			if (!hasOpened) {
				if (GameMaster.Instance.useKey()) {
					openGate();
				}
			}
		}
	}

	//Opens the gate
	void openGate() {
		hasOpened = true;
		gateClosed.SetActive(false);
		gateOpen.SetActive(true);
		gameObject.GetComponent<BoxCollider>().enabled = false;
	}
}

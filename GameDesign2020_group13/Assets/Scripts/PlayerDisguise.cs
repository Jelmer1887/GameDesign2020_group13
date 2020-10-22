using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisguise : MonoBehaviour
{
	public bool isDisguised;
	public float disguiseDuration;
	public float timer;
	public GameObject mask;

    // Start is called before the first frame update
    void Start()
    {
		timer = disguiseDuration;
		mask.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.E) && !isDisguised) {
			Debug.Log("Disguise!");
			isDisguised = true;
			mask.SetActive(true);
			gameObject.tag = "DisguisedPlayer";
		}

		if (isDisguised) {
			Debug.Log(timer);

			if (timer > 0) {
				timer -= Time.deltaTime;
			} else {
				Debug.Log("Time has run out!");
				timer = disguiseDuration;
				isDisguised = false;
				gameObject.tag = "Player";
			}
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisguise : MonoBehaviour
{
	bool isDisguised;
	public float disguiseDuration;
	public GameObject mask;

    // Start is called before the first frame update
    void Start()
    {
		mask.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.E) && !isDisguised) {
			isDisguised = true;
			mask.SetActive(true);
		}

		if (isDisguised) {
			if (disguiseDuration > 0) {
				disguiseDuration -= Time.deltaTime;
			} else {
				Debug.Log("Time has run out!");
				disguiseDuration = 0;
				isDisguised = false;
			}
		}
	}

}

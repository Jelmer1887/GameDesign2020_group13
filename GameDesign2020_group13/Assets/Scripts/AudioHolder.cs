using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHolder : MonoBehaviour
{
	private float timer;

    // Start is called before the first frame update
    void Start()
    {
		DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;

		if(timer >= 5) {
			Destroy(this.gameObject);
		}
    }
}

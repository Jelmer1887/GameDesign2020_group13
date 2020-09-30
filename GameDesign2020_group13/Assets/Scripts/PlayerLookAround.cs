using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour
{
	[SerializeField] Transform cam = null;
	[SerializeField] float sensitivity = 300f;
	[SerializeField] float headRotationLimit = 90f;
	float headRotation = 0f;

	
	void Start(){
		//Make sure the cursor is not visible and stays in the same place
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

    
    void Update(){
		//Get mouse input
		float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
		float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * -1f;

		//Rotate the player
		transform.Rotate(0f, x, 0f);

		//Rotate the camera
		headRotation += y;
		headRotation = Mathf.Clamp(headRotation, -headRotationLimit, headRotationLimit);
		cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);
	}
}

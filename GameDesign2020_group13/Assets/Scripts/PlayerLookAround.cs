using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour
{
	public Transform cam;
	public float sensitivity = 300f;
	public float headRotationLimit = 90f;
	private float headRotation = 0f;

	
	void Start(){
		//Make sure the cursor is not visible and stays in the same place
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

    
    void FixedUpdate(){
		//Get mouse input
		float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
		float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

		//Rotate the camera
		headRotation -= y;
		headRotation = Mathf.Clamp(headRotation, -headRotationLimit, headRotationLimit);
		cam.localRotation = Quaternion.Euler(headRotation, 0f, 0f);

		//Rotate the player
		transform.Rotate(Vector3.up * x);
	}
}

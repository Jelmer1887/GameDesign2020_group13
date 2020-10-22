using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody rb;
	public float speed = 6f;
	public float jumpForce = 4f;
	public Transform groundChecker = null;
	public float checkRadius = 0.25f;
	public LayerMask groundLayer = new LayerMask();

	public Transform cam;
	public float turnSmoothTime;
	private float turnSmoothVelocity;

	void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

	void FixedUpdate() {
		//Get movement input
		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw("Vertical");
		//Move player relative to its rotation
		Vector3 moveBy = new Vector3(x, 0f, z).normalized;

		if (moveBy.magnitude >= 0.1f) {
			float targetAngle = Mathf.Atan2(moveBy.x, moveBy.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			rb.MovePosition(transform.position + direction.normalized * speed * Time.deltaTime);
		}
	}

	private void Update() {
		//Jump
		if (Input.GetKeyDown(KeyCode.Space) && IsOnGround()) {
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}

	//Checks whether player is standing on ground, prevents jumping mid-air
	public bool IsOnGround() {
		Collider[] colliders = Physics.OverlapSphere(groundChecker.position, checkRadius, groundLayer);
		if (colliders.Length > 0) {
			return true;
		} else {
			return false;
		}
	}
}

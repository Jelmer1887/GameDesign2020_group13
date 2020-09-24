using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody rb;
	[SerializeField] float speed = 50;
	[SerializeField] float jumpForce = 4;
	[SerializeField] Transform groundChecker;
	[SerializeField] float checkRadius;
	[SerializeField] LayerMask groundLayer;

	void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

	void Update() {
		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw("Vertical");
		Vector3 moveBy = transform.right * x + transform.forward * z;
		rb.MovePosition(transform.position + moveBy.normalized * speed * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.Space) && IsOnGround()) {
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}

	public bool IsOnGround() {
		Collider[] colliders = Physics.OverlapSphere(groundChecker.position, checkRadius, groundLayer);
		if (colliders.Length > 0) {
			return true;
		} else {
			return false;
		}
	}
}

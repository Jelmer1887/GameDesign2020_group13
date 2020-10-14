using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
	private RaycastHit vision;
	public int sightReach = 5;
	public int fov = 60;
	GameObject player;
	Rigidbody rb;
	public int speed = 2;

	public Transform[] patrolPoints;
	int currentPatrolPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		transform.LookAt(patrolPoints[0].position);
	}

    // Update is called once per frame
    void Update()
    {
		if(player == null) {
			player = GameObject.FindGameObjectWithTag("Player");
		}

		if (Vector3.Distance(transform.position, player.transform.position) < sightReach) {
			float angle = Vector3.Angle(player.transform.position - transform.position, transform.forward);
			if (Mathf.Abs(angle) <= fov) {
				if(Physics.Raycast(transform.position, player.transform.position - transform.position, out vision)) {
					if (vision.collider.CompareTag("Player")) {
						GameMaster.Instance.respawnPlayer(vision.collider.gameObject);
					}
				}
			}
		}

		if(Vector3.Distance(transform.position, patrolPoints[currentPatrolPoint].position) == 0) {
			currentPatrolPoint++;
			if(currentPatrolPoint >= patrolPoints.Length) {
				currentPatrolPoint = 0;
			}
			transform.LookAt(patrolPoints[currentPatrolPoint].position);
		}
		transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPatrolPoint].position, speed * Time.deltaTime);
		

	}
}

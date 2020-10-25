using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wolf : MonoBehaviour
{
	private RaycastHit vision;
	public int fov = 60;

	public Transform[] patrolPoints;
	private int currentPatrolPoint = 0;

	private bool removedLife;

    // Start is called before the first frame update
    void Start()
    {
		GetComponent<NavMeshAgent>().SetDestination(patrolPoints[currentPatrolPoint].position);
	}

    // Update is called once per frame
    void Update()
    {
		Vector2 transformVector = new Vector2(transform.position.x, transform.position.z);
		Vector2 patrolVector = new Vector2(patrolPoints[currentPatrolPoint].position.x, patrolPoints[currentPatrolPoint].position.z);

		if(Vector2.Distance(transformVector, patrolVector) <= 0.5f) {
			currentPatrolPoint++;
			if(currentPatrolPoint >= patrolPoints.Length) {
				currentPatrolPoint = 0;
			}
			GetComponent<NavMeshAgent>().SetDestination(patrolPoints[currentPatrolPoint].position);
		}

	}

	private void OnTriggerStay(Collider other) {
		float angle = Vector3.Angle(other.transform.position - transform.position, transform.forward);
		if (angle <= 0.5*fov) {
			if (Physics.Raycast(transform.position, other.transform.position - transform.position, out vision)) {
				if (other.CompareTag("Player")) {
					if (!removedLife) {
						GameMaster.Instance.removeLife();
						removedLife = true;
					}
					GameMaster.Instance.respawnPlayer(vision.collider.gameObject);
					GetComponent<NavMeshAgent>().SetDestination(patrolPoints[currentPatrolPoint].position);
				} else if (other.CompareTag("DisguisedPlayer")) {
					float distance = Vector3.Distance(transform.position, other.transform.position);
					if (distance > 5.0f) {
						GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
					} else {
						GetComponent<NavMeshAgent>().SetDestination(Vector3.Scale(other.transform.position, new Vector3(0.5f, 1f, 0.5f)));
					}
				}
			}
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.CompareTag("DisguisedPlayer")) {
			GetComponent<NavMeshAgent>().SetDestination(patrolPoints[currentPatrolPoint].position);
		}

		if (other.CompareTag("Player")) {
			removedLife = false;
		}
	}
}

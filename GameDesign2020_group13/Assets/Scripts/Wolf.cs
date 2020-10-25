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
		if (other.CompareTag("Player")) {
			float angle = Vector3.Angle(other.transform.position - transform.position, transform.forward);
			if (Mathf.Abs(angle) <= 0.5*fov) {
				if (Physics.Raycast(transform.position, other.transform.position - transform.position, out vision)) {
					if (!removedLife) {
						GameMaster.Instance.removeLife();
						removedLife = true;
					}
					GameMaster.Instance.respawnPlayer(vision.collider.gameObject);
				}
			}
		} else if(other.CompareTag("DisguisedPlayer")){
			GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
		if(player == null) {
			player = GameObject.FindGameObjectWithTag("Player");
		}

		if (Vector3.Distance(transform.position, player.transform.position) < sightReach && Vector3.Angle(player.transform.position - transform.position, transform.forward) <= fov) {
			GameMaster.Instance.respawnPlayer();
		}

		if(Vector3.Distance(transform.position, patrolPoints[currentPatrolPoint].position) < 0.5f) {
			currentPatrolPoint++;
			if(currentPatrolPoint >= patrolPoints.Length) {
				currentPatrolPoint = 0;
			}
		}
		transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPatrolPoint].position, speed * Time.deltaTime);
		

	}
}

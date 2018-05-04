using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
	public float rotationSpeed;
	public float timeToChangeDirection;
	public float speed;
	float initialTime;
	Rigidbody rb;
	Vector3 direction;
	public GameObject player;
	float speedStart;
	bool gameOver = false;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		speedStart = speed;
	}

	void Update() {
		if (gameOver == false) {
			if (player.transform.position.y > 25f) {
				speed = speedStart;
				direction = player.transform.position - rb.position;
				direction.Normalize ();
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotationSpeed * Time.deltaTime);
			} else {
				speed = 10f;
				direction = new Vector3 (Random.Range (-50, 50), 0, Random.Range (-50, 50));

			}
		}
	}

	void FixedUpdate() {
		rb.AddForce(direction * speed);
	}
		
	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "player") 
		{
			Destroy(collider.gameObject);
			gameOver = true;
		}
	}
}

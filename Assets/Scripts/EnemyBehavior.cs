using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
	public float rotationSpeed;
	public float timeToChangeDirection;
	public float speed;
	public GameObject player;
	public Transform target;
	float initialTime;
	Rigidbody rb;
	Vector3 direction;
	float speedStart;
	public static bool gameOver = false;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		speedStart = speed;
		player = GameObject.FindGameObjectWithTag ("player");
	}

	void Update() {
		if (player.transform.position.y > 25f) {
			speed = speedStart;
			direction = player.transform.position - rb.position;
			direction.Normalize ();
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotationSpeed * Time.deltaTime);
		} else {
			speed = 2f;
			direction = transform.forward;
			transform.Rotate (0, Random.Range(-180f, 180f) * Time.deltaTime, 0);
			//transform.eulerAngles += Vector3.up * 10 * Time.deltaTime;
			//direction = new Vector3 (Random.Range (-50, 50), 0, Random.Range (-50, 50));
		}
	}

	void FixedUpdate() {
		//transform.LookAt (target);
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

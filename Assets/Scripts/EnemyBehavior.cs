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
	float angle;
	public float distanceFromPlayer;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		speedStart = speed;
		player = GameObject.FindGameObjectWithTag ("player");
	}

	void Update() {

		if (GameObject.Find("PlayerBall") != null){
			if (player.transform.position.y > distanceFromPlayer) {
				speed = speedStart;
				direction = player.transform.position - rb.position;
				direction.Normalize ();
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotationSpeed * Time.deltaTime);
			} else {
				angle = Random.Range (-180f, 180f);
				speed = 2f;
				direction = transform.forward;
				transform.Rotate (0, angle * Time.deltaTime, 0);
			}
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

		if (collider.gameObject.tag == "border") 
		{
			Debug.Log ("enemy collided border");
			ChangeDirection ();
		}
	}

	void ChangeDirection() 
	{
		angle *= -1;
		speed = 2f;
		direction = transform.forward;
		transform.Rotate (0, angle * Time.deltaTime, 0);
	}
}

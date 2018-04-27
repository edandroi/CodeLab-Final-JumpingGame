using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {
	public float timeToChangeDirection;
	public float speed;
	float initialTime;
	Rigidbody rb;

	// Use this for initialization
	public void Start () {
		initialTime = timeToChangeDirection;
		ChangeDirection();
	}

	// Update is called once per frame
	public void Update () {
		timeToChangeDirection -= Time.deltaTime;

		if (timeToChangeDirection <= 0) {
			ChangeDirection();
			timeToChangeDirection = initialTime;
		}

		transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}

	void ChangeDirection() 
	{
		float angle = Random.Range (0f , 360f);
//		Quaternion newDirection = Quaternion.Euler (angle, 0, angle);
		transform.rotation = Quaternion.Euler (0, angle, 0);
	}
}
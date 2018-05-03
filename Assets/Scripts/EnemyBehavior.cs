using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
	public float rotationSpeed;
	public float timeToChangeDirection;
	public float speed;
	float initialTime;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		initialTime = timeToChangeDirection;
		ChangeDirection();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, rotationSpeed,0)*Time.deltaTime);

		timeToChangeDirection -= Time.deltaTime;

		if (timeToChangeDirection <= 0) {
			ChangeDirection();
			timeToChangeDirection = initialTime;
		}

		transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "player") 
		{
			Destroy(collider.gameObject);
		}
	}

	void ChangeDirection() 
	{
		float angle = Random.Range (0f , 360f);
		transform.rotation = Quaternion.Euler (0, angle, 0);
	}
}

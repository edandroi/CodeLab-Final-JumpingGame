using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour {
	public float timeToChangeDirection;
	public float speed;
	float initialTime;
	public GameObject explosion;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		initialTime = timeToChangeDirection;
		ChangeDirection();
	}
	
	// Update is called once per frame
	void Update () {
		timeToChangeDirection -= Time.deltaTime;

		if (timeToChangeDirection <= 0) {
			ChangeDirection();
			timeToChangeDirection = initialTime;
		}

		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		
	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.tag == "player") 
		{
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
			GameManager.score++;

		}
	}

	void ChangeDirection() 
	{
		float angle = Random.Range (0f , 360f);
		transform.rotation = Quaternion.Euler (0, angle, 0);
	}
}

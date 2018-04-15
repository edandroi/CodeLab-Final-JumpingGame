using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public KeyCode keyUp;
	public KeyCode keyDown;
	public KeyCode keyRight;
	public KeyCode keyLeft;
	public float speed;
	public float jumpSpeed;
	float jumpSpeedStart;
	public bool jump = false;

	// Use this for initialization
	void Start () {
		jumpSpeedStart = jumpSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(keyRight))
		{
			transform.position += new Vector3(1,0,0)*speed*Time.deltaTime;
		}

		if (Input.GetKey(keyLeft))
		{
			transform.position += new Vector3(-1,0,0)*speed*Time.deltaTime;
		}

		if (Input.GetKey (keyUp)) {
			transform.position += new Vector3(0,0,1)*speed*Time.deltaTime;
		}

		if (Input.GetKey (keyDown)) {
			transform.position += new Vector3 (0, 0, -1) * speed * Time.deltaTime;
		}


		if (jump == true) 
		{
			GetComponent<Rigidbody> ().useGravity = false;
			Jump ();
		}

		if (jump == false) 
		{
			GetComponent<Rigidbody> ().useGravity = true;
			jumpSpeed = jumpSpeedStart;
		}



	}


	void OnTriggerEnter ()
	{
		jump = true;
	}

	void Jump ()
	{
		transform.position += new Vector3(0,1,0)*jumpSpeed*Time.deltaTime;
		jumpSpeed -= 0.1f;

		if (jumpSpeed <= 0.5) {
			jump = false;

		}

	}
}

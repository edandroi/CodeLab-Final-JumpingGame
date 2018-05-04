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
	public bool dead = false;
	private Rigidbody playerRb;
	public GameObject explosion;


	// Use this for initialization
	void Start () {
		jumpSpeedStart = jumpSpeed;
		playerRb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {



		//PLAYER MOVEMENT

		if (Input.GetKey(keyRight))
		{
			transform.position += transform.right*speed*Time.deltaTime;
		}

		if (Input.GetKey(keyLeft))
		{
			transform.position -= transform.right*speed*Time.deltaTime;
		}

		if (Input.GetKey (keyUp)) {
			transform.position += transform.forward*speed*Time.deltaTime;
		}

		if (Input.GetKey (keyDown)) {
			transform.position -= transform.forward * speed * Time.deltaTime;
		}

//		if (Input.GetKeyDown (KeyCode.D)) {
//			GameManager.ToggleCamera ();
//			dead = true;
//			Destroy (gameObject);
//			Instantiate (explosion, transform.position, transform.rotation);
//		}

		//JUMP ANIMATION

		var originalScale = transform.localScale;
		var middleScale = new Vector3 (0.5f, 2f, 0.5f);
		var hitScale = new Vector3 (1.5f, 0.5f, 1.5f);




//		float currentSpeed = Mathf.Abs (playerRb.velocity);
//
//		if (currentSpeed <= 2.0f) {
//			transform.localScale = Vector3.Lerp(middleScale, originalScale, playerRb.velocity/jumpSpeed);
//
//		}

	}


	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "ground") 
		{
			Jump ();
		}
		if (collider.gameObject.tag == "enemy") 
		{
			GameManager.ToggleCamera ();
			dead = true;
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
	
		}
	}

	void Jump ()
	{

		playerRb.velocity = new Vector3 (0, jumpSpeed, 0);

	}
}

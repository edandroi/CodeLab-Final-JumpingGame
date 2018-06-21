using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public KeyCode keyUp;
	public KeyCode keyDown;
	public KeyCode keyRight;
	public KeyCode keyLeft;
	public float speed;
	float speedCurrent; 
	public float ease;
	public float jumpSpeed;
	float jumpSpeedStart;
	public bool jump = false;
	public bool dead = false;
	private Rigidbody playerRb;
	public GameObject explosion;

	private Vector3 originalScale;

	public float fallSpeed;

	// AUDIO
	public AudioClip scoreSound;
	public AudioSource scoreSoundSource;

	// INTERACTIONS WITH OBJECTS
	//shield
	public bool shielded = false;
	public float timerShield;
	float timerShieldCountdown;
	//safe jump
	public float safeJumpSpeed;
	bool safeJump = false;


	// Use this for initialization
	void Start () {
		timerShieldCountdown = timerShield;
		jumpSpeedStart = jumpSpeed;
		playerRb = GetComponent<Rigidbody> ();
		originalScale = transform.localScale;
		speedCurrent = 0f;
		scoreSoundSource = GetComponent<AudioSource> ();

		// SCORE SOUND
		scoreSoundSource.playOnAwake = false;
		scoreSoundSource.clip = scoreSound;
	}
	
	// Update is called once per frame
	void Update () {


		//PLAYER MOVEMENT

		if (Input.GetKey(keyRight))
		{	
			transform.position += transform.right * speedCurrent * Time.deltaTime;
			if (speedCurrent < speed) {
				speedCurrent += ease;
			}
		}

		if (Input.GetKey(keyLeft))
		{	
			transform.position -= transform.right*speedCurrent*Time.deltaTime;
			if (speedCurrent < speed) {
				speedCurrent += ease;
			}
		}

		if (Input.GetKey (keyUp)) 
		{
			transform.position += transform.forward*speedCurrent*Time.deltaTime;
			if (speedCurrent < speed) {
				speedCurrent += ease;
			}
		}

		if (Input.GetKey (keyDown)) {
			transform.position -= transform.forward * speedCurrent * Time.deltaTime;
			if (speedCurrent < speed) {
				speedCurrent += ease;
			}
		}

		Debug.Log ("shielded is" + shielded);

		//JUMP ANIMATION

		var middleScale = new Vector3 (0.5f, 2f, 0.5f);
//		var hitScale = new Vector3 (1.5f, 0.5f, 1.5f);
		Debug.Log("Jump Speed is "+jumpSpeed);


		fallSpeed = Mathf.Abs (playerRb.velocity.y);
		transform.localScale = Vector3.Lerp (originalScale, middleScale, fallSpeed / jumpSpeed);
	}


		void OnTriggerEnter (Collider collider)
		{
			if (collider.gameObject.tag == "ground") 
			{
				Jump ();
				if (safeJump == true) {
				jumpSpeed += 1f;
				}
			}
			if (collider.gameObject.tag == "enemy") 
			{
				if (shielded == false) {
					GameManager.ToggleCamera ();
					dead = true;
					Destroy (gameObject);
					Instantiate (explosion, transform.position, transform.rotation);
				} 
			}
			if (collider.gameObject.tag == "score") 
			{
				ScoreSound ();
			}


			// SAFE JUMP
			if (collider.gameObject.tag == "safeJump")
			{
				safeJump = true;
				jumpSpeed = safeJumpSpeed;

				if (safeJumpSpeed == jumpSpeedStart) {
					safeJump = false;
				}
			}

			// SHIELD
			if (collider.gameObject.tag == "shield") 
			{
				shielded = true;
			}
			
			if (shielded == true) 
			{
	
			timerShieldCountdown -= Time.deltaTime ;

					if (timerShield <= 0)
					{
						shielded = false;
						timerShieldCountdown = timerShield;
					}	
			}	
	}

	void Jump ()
	{

		playerRb.velocity = new Vector3 (0, jumpSpeed, 0);

	}

	void ScoreSound()
	{
		GetComponent<AudioSource> ().Play ();
	}
}

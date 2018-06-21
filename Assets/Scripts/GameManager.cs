using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	public bool play = false;

	public Camera playerCameraRef;

	public static Camera camPlayer;
	public static Camera camScene;
	public static Camera camDown;
	public GameObject shieldObj;
	public GameObject scoreObj;
	public GameObject jumpObj;
	public GameObject enemy; 
	public float numOfShields;
	public float numOfScores;
	public float numOfEnemies;
	public float numOfJumps;
	public KeyCode changeCam;
	public KeyCode startKey;
//	bool camSwitch = false;
	int i;
	int s;
	int e;
	int j;
	float xValue;
	float zValue;
	float z;
	static bool playerCamera = false;
	public static int score = 0;
	public bool playCam;
	public float timer = 2f;
//	public Text scoreText;

	public GameObject playerCamObj;

	void Start () {


		camDown = GameObject.Find ("CameraDown").GetComponent<Camera> ();
		camPlayer = GameObject.Find ("PlayerBall/PlayerCamera").GetComponent<Camera>();
		camScene = GameObject.Find ("Main Camera").GetComponent<Camera> ();


		// TWO CAMERAS
		camDown.enabled = false;
		camPlayer.enabled = false;
		camScene.enabled = true;

		//SHIELD SPAWN
			
			for (i = 0; i < numOfShields; i++) {
				z = Random.Range (0, 60);
				xValue = Random.Range(-30, 30);
				zValue = Random.Range(-30, 30);	
				Instantiate (shieldObj, new Vector3 (xValue, 0, zValue), new Quaternion (0, z, 0, 0));
			}
		//SAFEJUMP SPAWN

			for (j = 0; j < numOfJumps; j++) {
				z = Random.Range (0, 60);
				xValue = Random.Range(-30, 30);
				zValue = Random.Range(-30, 30);	
				Instantiate (jumpObj, new Vector3 (xValue, 0, zValue), new Quaternion (0, z, 0, 0));
			}

		//GOAL SPAWN
			for (s = 0; s < numOfScores; s++) {
				z = Random.Range (0, 60);
				xValue = Random.Range(-30, 30);
				zValue = Random.Range(-30, 30);	
				Instantiate (scoreObj, new Vector3 (xValue, 0, zValue), new Quaternion (0, z, 0, 0));
			}
		//ENEMY SPAWN
			for (e = 0; e < numOfEnemies; e++) {
				z = Random.Range (0, 60);
				xValue = Random.Range(-30, 30);
				zValue = Random.Range(-30, 30);	
				Instantiate (enemy, new Vector3 (xValue, 30f, zValue), new Quaternion (0, z, 0, 0));
			}
		

	}

	public static void ToggleCamera()
	{
		playerCamera = !playerCamera;

		if (playerCamera) {
			camPlayer.enabled = true;
			camScene.enabled = false;
			camDown.enabled = false;
		} else {
			camPlayer.enabled = false;
			camScene.enabled = false;
			camDown.enabled = true;
		}
	}

	void Update () {

		playCam = playerCamera;
		if (camPlayer == null) {
			camScene.enabled = true;
			camDown.enabled = false;
		}
		if (EnemyBehavior.gameOver == false) {
			// SWITCHING BETWEEN CAMERAS
			if (Input.GetKeyDown (changeCam)) {
				ToggleCamera ();
			}

			if (Input.GetKeyDown (startKey)) {
				SceneManager.LoadScene ("Game");
			}

		}
		else
		{
			timer = timer - Time.deltaTime;

			if (timer <= 0)
			{
				SceneManager.LoadScene("Level00");
			}
	
		}
	}
		
}

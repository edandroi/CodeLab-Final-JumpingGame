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
	public GameObject mineObj;
	public GameObject scoreObj;
	public GameObject enemy; 
	public float numOfMines;
	public float numOfScores;
	public float numOfEnemies;
	public KeyCode changeCam;
	public KeyCode startKey;
	bool camSwitch = false;
	int i;
	int s;
	int e;
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

		//MINE SPAWN
			
			for (i = 0; i < numOfMines; i++) {
				z = Random.Range (0, 60);
				xValue = Random.Range(-30, 30);
				zValue = Random.Range(-30, 30);	
				Instantiate (mineObj, new Vector3 (xValue, 0, zValue), new Quaternion (0, z, 0, 0));
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
			Debug.Log ("GameOver");
			timer = timer - Time.deltaTime;

			if (timer <= 0)
			{
				SceneManager.LoadScene("Level00");
			}
	
		}
	}
		
}

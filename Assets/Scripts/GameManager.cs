using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static Camera camPlayer;
	public static Camera camScene;
	public GameObject mineObj;
	public GameObject scoreObj;
	public GameObject enemy; 
	public float numOfMines;
	public float numOfScores;
	public float numOfEnemies;
//	public Transform enemySpawnPoints[];
	public KeyCode changeCam;
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

	void Start () {
		camPlayer = GameObject.Find ("PlayerCamera").GetComponent<Camera> ();
		camScene = GameObject.Find ("Main Camera").GetComponent<Camera> ();
//		camPlayerDown = 

		// TWO CAMERAS
		camPlayer.gameObject.SetActive(false);
		camScene.gameObject.SetActive (true);

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
			camPlayer.gameObject.SetActive (true);
			camScene.gameObject.SetActive (false);
		} else {
			camScene.gameObject.SetActive (true);
			camPlayer.gameObject.SetActive (false);
		}
	}

	void Update () {
		playCam = playerCamera;

		if (camPlayer == null) {
			camScene.gameObject.SetActive (true);
		}
		// SWITCHING BETWEEN CAMERAS
		if (Input.GetKeyDown (changeCam)) 
		{
			ToggleCamera ();
		}
			
		Debug.Log (score);
	}
}

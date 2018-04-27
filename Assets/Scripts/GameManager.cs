using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Camera camPlayer;
	public Camera camScene;
	public GameObject enemy;
	public float numOfEnemies;
//	public Transform enemySpawnPoints[];
	public KeyCode changeCam;
	bool camSwitch = false;
	int i;
	float xValue;
	float zValue;
	float z;

	void Start () {
		// TWO CAMERAS
		camPlayer.gameObject.SetActive(false);
		camScene.gameObject.SetActive (true);

		//ENEMY SPAWN
			
			for (i = 0; i < numOfEnemies; i++) {
				z = Random.Range (0, 60);
				xValue = Random.Range(-30, 30);
				zValue = Random.Range(-30, 30);	
				Instantiate (enemy, new Vector3 (xValue, 0, zValue), new Quaternion (0, z, 0, 0));
			}
		

	}

	void Update () {

		// SWITCHING BETWEEN CAMERAS
		if (Input.GetKeyDown (changeCam)) 
		{
			camSwitch = !camSwitch;
			camPlayer.gameObject.SetActive (!camSwitch);
			camScene.gameObject.SetActive (camSwitch);
		}

//		if (GameObject.Find ("PlayerBall").GetComponent<PlayerMovement> ().dead = true)
//		{
//
//			camScene.gameObject.SetActive (true);
//			camPlayer.gameObject.SetActive (false);
//		
//		}
	}
}

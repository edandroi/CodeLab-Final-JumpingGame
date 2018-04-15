using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Camera camPlayer;
	public Camera camScene;
	public KeyCode changeCam;
	bool camSwitch = false;

	// Use this for initialization
	void Start () {
		
		camPlayer.gameObject.SetActive(false);
		camScene.gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (changeCam)) 
		{
			camSwitch = !camSwitch;
			camPlayer.gameObject.SetActive (!camSwitch);
			camScene.gameObject.SetActive (camSwitch);
		}
//		if (camPlayer.gameObject.SetActive == false) 
//		{
//			camPlayer.gameObject.SetActive (true);
//		} else 
//		{
//			camPlayer.gameObject.SetActive (false);
//		}
//
//		if (camScene.gameObject.SetActive == true) {
//			camScene.gameObject.SetActive (false);
//		} else 
//		{
//			camScene.gameObject.SetActive (true);
//		}
	}
}

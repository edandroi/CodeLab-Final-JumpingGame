﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");

		transform.Rotate (-mouseY * Time.deltaTime*rotationSpeed, mouseX * Time.deltaTime*rotationSpeed, 0);
		transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);
	}
}

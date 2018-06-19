using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDownBehavior : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;
	Vector3 offset;

	float xValue;
	float zValue;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
//		xValue = GameObject.Find ("PlayerBall").GetComponent<Transform> ().position.x;
//		zValue = GameObject.Find ("PlayerBall").GetComponent<Transform> ().position.z;
//		transform.position = new Vector3 (xValue, 0, zValue);
	}

	void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}

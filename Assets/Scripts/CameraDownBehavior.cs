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
//		Vector3 targetPos = new Vector3 (xValue, 0, zValue);
//		offset = transform.position - targetPos;
//		transform.Translate (offset.normalized * Time.deltaTime);
//		Debug.Log (transform.position.x);
	}

	void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + offset;
		Vector3 eliminateYPos = new Vector3 (1, 0, 1);
		Vector3 targetCamPos2d = Vector3.Scale (targetCamPos, eliminateYPos);
		transform.position = Vector3.Lerp (transform.position, targetCamPos2d, smoothing * Time.deltaTime);
	}
}

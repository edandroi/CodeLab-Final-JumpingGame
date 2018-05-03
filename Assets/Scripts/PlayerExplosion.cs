using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour {

	ParticleSystem explosion;
	public float timer;
	// Use this for initialization
	void Start () {
		explosion = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) 
		{
			Destroy (gameObject);
		}
	}
}

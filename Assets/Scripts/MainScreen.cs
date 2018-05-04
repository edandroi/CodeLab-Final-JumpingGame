using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainScreen : MonoBehaviour {
	public bool play = false;
	UnityEvent m_MyEvent = new UnityEvent();
	// Use this for initialization
	void Start () {
		m_MyEvent.AddListener(StartGame);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && m_MyEvent != null)
		{
			//Begin the action
			m_MyEvent.Invoke();
		}
	}

	void StartGame()
	{
		play = true;
	}

//	void OnMouseDown()
//	{
//		play = true;
////		gameObject.SetActive (false);
////		foreach (GameObject textObj in texts) {
////			textObj.SetActive (false);
////		}
//
//	
//	}
}

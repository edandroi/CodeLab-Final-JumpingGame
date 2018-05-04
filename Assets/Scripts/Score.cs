using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

		public Text textbox;

		void Start()
		{
			textbox = GetComponent<Text>();
		}

		void Update()
		{
		
			textbox.text = "Score: " + GameManager.score;
		}
	}

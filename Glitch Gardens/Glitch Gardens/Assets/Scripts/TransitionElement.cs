using UnityEngine;
using System.Collections;

public class TransitionElement : MonoBehaviour {

		float time;
		float transition;
		public LevelManager levelmanager;
	// Use this for initialization
	void Start () {
		time = Time.time;
		transition = time + 5;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			if(time <= transition){
				levelmanager.LoadLevel("Start Menu");
			}
		}
	}

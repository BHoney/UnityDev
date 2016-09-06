using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour {
	public int currentscore = 0;
	public Text scoreboard;


	// Use this for initialization
	void Start () {
		scoreboard = gameObject.GetComponent<Text>();
		Reset();
	}

	public void Score(int score){
		currentscore+=score;
		scoreboard.text = currentscore.ToString();
	}

	void Reset(){
		currentscore = 0;
		scoreboard.text = currentscore.ToString();
	}
}

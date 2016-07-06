using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public int maxHits;
	private int hits;
	private LevelManager lm;
	// Use this for initialization
	void Start () {
		hits = 0;
		lm = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(hits);
		if(hits == maxHits){Destroy(gameObject);}
	}

	void OnCollisionEnter2D(Collision2D collider)
	{hits++;}
		//SimulateWin();

	//TODO: Remove this once we have real win conditions
	void SimulateWin(){lm.loadNextLevel();
	}
		
}

using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager LM;

	void Start(){
		LM = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log("Trigger entered.");
		LM.LoadLevel("Lose Screen");
	}


}

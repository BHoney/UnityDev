using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	public LevelManager LM;

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log("Trigger entered.");
		LM.LoadLevel("Win Screen");
	}


}

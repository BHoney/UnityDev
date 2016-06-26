using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	float mousePosInBlocks;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		mousePosInBlocks = (Input.mousePosition.x / Screen.width )*16;
		Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, 0);
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0f, 15f); //This value updates here, so clamp here
		this.transform.position = paddlePos;
		//transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, 0.5f, 15.5f))
	}
}

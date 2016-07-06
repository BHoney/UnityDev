using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	// Use this for initialization
	private Paddle paddle;
	private Vector3 paddleToBallDist;
	private Rigidbody2D rb2d;
	private bool isStarted;
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallDist = this.transform.position - paddle.transform.position;
		rb2d = GetComponent<Rigidbody2D>();
		isStarted = false;

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(paddleToBallDist);
		if(!isStarted){
		this.transform.position = paddle.transform.position + paddleToBallDist;
		if(Input.GetMouseButtonDown(0)){
			Debug.Log("Clicked.");
				isStarted = true;
				rb2d.velocity = new Vector2((paddle.transform.position.x/5), 12.75f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.name == ("Paddle"))
		{
		}
	}
}
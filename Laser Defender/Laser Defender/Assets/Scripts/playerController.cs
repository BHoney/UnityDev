using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	public enum Direction {Left, Right};
	public float moveSpeed;
	private float moveH = 0f;
	public float padding = .5f;
	float xmin;
	float xmax;
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector2 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distance));
		xmin=leftMost.x+padding;
		xmax=rightMost.x-padding;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.LeftArrow)) move(Direction.Left);
		if(Input.GetKey(KeyCode.RightArrow)) move(Direction.Right);
		gameObject.transform.position = new Vector2(moveH*Time.deltaTime, transform.position.y);
		

	}

	void Update(){
		float boundaries = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector2(boundaries, transform.position.y);
	}

	void move(Direction direction){
		switch (direction)
		{
			case Direction.Left:
				moveH-=moveSpeed;
			break;

			case Direction.Right:
				moveH+=moveSpeed;
			break;
			default:
			return;
		}
	}
}

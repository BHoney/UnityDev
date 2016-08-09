using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	public enum Direction {Left, Right};
	public float moveSpeed = 5f;
	private float moveH = 0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.LeftArrow)) move(Direction.Left);
		if(Input.GetKey(KeyCode.RightArrow)) move(Direction.Right);
		gameObject.transform.position = new Vector2(moveH, 0);

	}

	void move(Direction direction){
		switch (direction)
		{
			case Direction.Left:
				moveH--;
			break;

			case Direction.Right:
				moveH++;
			break;
			default:
			return;
		}
	}
}

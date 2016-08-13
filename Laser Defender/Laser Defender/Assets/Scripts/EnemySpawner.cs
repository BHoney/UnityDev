using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public enum Direction { Left, Right };
    public float width;
    public float height;
    private bool moveRight;
    public float movespeed = 1f;
	public float xmin, xmax;
    // Use this for initialization
    void Start()
    {
		moveRight = (Random.Range(0,2) == 0);
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = (Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance)));
		Vector3 rightmost = (Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance)));
		xmin = leftmost.x;
		xmax = rightmost.x;
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.SetParent(child);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector2(width, height));
    }

    // Update is called once per frame
	void Update(){
		
		float leftEdge = transform.position.x - width*.5f;
		float rightEdge = transform.position.x + width*.5f;
		if(leftEdge < xmin) moveRight = true;
		else if (rightEdge > xmax) moveRight = false;


		 //float boundaries = Mathf.Clamp(transform.position.x, xmin, xmax);
		 //transform.position = new Vector2(boundaries, transform.position.y);
	}


    void FixedUpdate()
    {
        float boundaries = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector2(boundaries, transform.position.y);
        if (moveRight) move(Direction.Right);
        else move(Direction.Left);
    }

    void move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                transform.position -=new Vector3(movespeed * Time.deltaTime, 0);
                break;
            case Direction.Right:
                transform.position += new Vector3(movespeed * Time.deltaTime, 0);
                break;
            default:
                return;
        }
    }
}

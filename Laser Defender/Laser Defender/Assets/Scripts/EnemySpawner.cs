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
    public float SpawnDelay = .5f;
    // Use this for initialization
    void Start()
    {
        moveRight = (Random.Range(0, 2) == 0);
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)));
        Vector3 rightmost = (Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)));
        xmin = leftmost.x;
        xmax = rightmost.x;
        // SpawnEnemies();
        SpawnEnemy();

    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector2(width, height));
    }

    // Update is called once per frame
    void Update()
    {

        if (AllEnemiesDead())
        {
            // SpawnEnemies();
            // Invoke("SpawnEnemies", 2);
        }
        else{
            SpawnEnemy();
        }
       
        //float boundaries = Mathf.Clamp(transform.position.x, xmin, xmax);
        //transform.position = new Vector2(boundaries, transform.position.y);
    }


    void FixedUpdate()
    {
        float boundaries = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector2(boundaries, transform.position.y);
        if (moveRight) move(Direction.Right);
        else move(Direction.Left);

        float leftEdge = transform.position.x - width * .5f;
        float rightEdge = transform.position.x + width * .5f;
        if (leftEdge < xmin) moveRight = true;
        else if (rightEdge > xmax) moveRight = false;
    }

    bool AllEnemiesDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            //If any of the gameObjects are left, return false so we can keep shooting
            if (childPositionGameObject.childCount > 0) { return false; }
        }
        return true;
    }

    Transform NextFreePosition()
    {
        foreach (Transform position in transform)
        {
            if (position.childCount == 0)
            {
                return position;
            }
        }
        return null;
    }

    void move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                transform.position -= new Vector3(movespeed * Time.deltaTime, 0);
                break;
            case Direction.Right:
                transform.position += new Vector3(movespeed * Time.deltaTime, 0);
                break;
            default:
                return;
        }
    }

    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.GetComponent<Projectile>())
        {
            print("Laser hit");
        }
    }

    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            Debug.Log("Spawning");
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.SetParent(child);
        }
    }


    void SpawnEnemy()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.SetParent(freePosition);
           // CancelInvoke("SpawnEnemy");
        }
        if(NextFreePosition()) Invoke("SpawnEnemy", SpawnDelay);
    }
}

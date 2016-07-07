using UnityEngine;
using System.Collections;

[System.Serializable]
public class Brick : MonoBehaviour
{

    public int maxHits;
    private int hits;
    private LevelManager lm;
    private SpriteRenderer sprite;
    public AudioClip crack;
    public static int breakableCount = 0;
    // Use this for initialization
    private bool isBreakable;
    void Awake()
    {
        isBreakable = (this.tag == "Breakable");
        sprite = this.GetComponent<SpriteRenderer>();
        SetColor(maxHits);
        breakableCount = GameObject.FindGameObjectsWithTag("Breakable").Length;
    }

    void Start()
    {
        isBreakable = (isBreakable);
        hits = 0;
        lm = GameObject.FindObjectOfType<LevelManager>();

    }

    void SetColor(int hits)
    {
        if (isBreakable)
        {
            Debug.Log("Setting Colors");
            switch (hits)
            {
                case 3:
                    sprite.color = Color.green;
                    break;
                case 2:
                    sprite.color = Color.yellow;
                    break;
                default:
                    sprite.color = Color.red;
                    break;
            }
        }
        else
        {
            sprite.color = Color.grey;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(string.Format("There are {0} breakable bricks in the scene", breakableCount));

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (isBreakable)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            handleHits();
        }
    }

    void handleHits()
    {
        Debug.Log("Hit");
        hits++;
        SetColor(maxHits - hits);
        if (hits == maxHits)
        {
            breakableCount--;
            lm.BrickDestroyed();
            Destroy(gameObject);
        }
    }
}

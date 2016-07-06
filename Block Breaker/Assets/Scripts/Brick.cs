using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    public int maxHits;
    private int hits;
    private LevelManager lm;
    private SpriteRenderer sprite;
    // Use this for initialization
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        SetColor(maxHits);
    }

    void Start()
    {
        hits = 0;
        lm = GameObject.FindObjectOfType<LevelManager>();

    }

    void SetColor(int hits)
    {
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

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(hits);
        if (hits == maxHits) { Destroy(gameObject); }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        hits++;
        SetColor(maxHits - hits);
    }
    //SimulateWin();

    //TODO: Remove this once we have real win conditions
    void SimulateWin()
    {
        lm.loadNextLevel();
    }

}

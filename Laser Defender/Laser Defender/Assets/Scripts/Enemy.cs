using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public GameObject laser;
    private float delay;
	public float projectSpeed;
	public float fireRate;
    public int points;
    private Scorekeeper scoreboard;
    public AudioClip destroyed;

    void Start(){
        scoreboard = GameObject.Find("ScoreKeeper").GetComponent<Scorekeeper>();
    }

    void Update()
    {

        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Projectile>())
        {
            Projectile projectile = other.GetComponent<Projectile>();
            health -= projectile.GetDamage();
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(destroyed, transform.position);
                Destroy(gameObject);
                scoreboard.Score(points);
            }
            projectile.hit();
            Debug.Log("Laser hit");
        }

    }
	
	void FixedUpdate(){
		delay = Time.deltaTime * fireRate;
        if (Random.value < delay)
        {
			Attack();
            //InvokeRepeating("Attack", 2, 100f);
        }
	}

    void Attack()
    {
		Vector3 gunPosition = new Vector3(0, -1);
        GameObject projectile = Instantiate(laser, gameObject.transform.position+gunPosition, Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = Vector2.down * projectSpeed;
        //timeToNextFire = Time.deltaTime + Random.value;
    }
}

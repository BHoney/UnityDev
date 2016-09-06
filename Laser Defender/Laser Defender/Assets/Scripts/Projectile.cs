using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public int damage;
	public AudioClip soundEffect;

	void Start(){
		AudioSource.PlayClipAtPoint(soundEffect, transform.position);
	}

	public void hit(){
		Destroy(gameObject);
	}

	public int GetDamage(){
		return damage;
	}

}

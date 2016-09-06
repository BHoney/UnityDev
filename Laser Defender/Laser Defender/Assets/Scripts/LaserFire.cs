using UnityEngine;
using System.Collections;

public class LaserFire : MonoBehaviour {

	public GameObject laserPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
			laser.transform.SetParent(gameObject.transform);
			laser.transform.position += Vector3.up * Time.deltaTime;
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, .15f);
	}
}

using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
    // Use this for initialization
    static MusicPlayer instance = null;
    void Awake()
    {
        Debug.Log("Music Player Awake" + GetInstanceID());
        if (instance)
        {
            Destroy(gameObject);
            Debug.Log("Self-Destruction of duplicate");
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    void Start () {
        Debug.Log("Music Player Start " + GetInstanceID());
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

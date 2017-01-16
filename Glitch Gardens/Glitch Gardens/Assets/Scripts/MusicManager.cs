using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
	public AudioClip[] musicCollection ;
    private AudioSource currentAudio { get; set; }

    // Use this for initialization
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start() { 
        currentAudio = GetComponent<AudioSource>();
        currentAudio.clip = musicCollection[SceneManager.GetActiveScene().buildIndex];
        currentAudio.Play();
	}

    void OnLevelWasLoaded( int level)
    {
        AudioClip newScene = musicCollection[level];
        
        if (newScene != null)
        {
            currentAudio.clip = newScene;
            currentAudio.loop = true;
            currentAudio.Play();
            Debug.Log(string.Format("Playing {0}", currentAudio.clip.name));
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashScreen : MonoBehaviour {


    [SerializeField] private MusicManager musicManager;
    // Use this for initialization


    void Start()
    {
        Invoke("LoadStart", musicManager.musicCollection[0].length);
    }
	
	void LoadStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

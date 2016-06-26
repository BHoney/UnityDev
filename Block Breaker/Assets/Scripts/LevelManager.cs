using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        Debug.Log("Loading "+ name);
        UnityEngine.SceneManagement.SceneManager.LoadScene(name); 
        
    }

    public void Quit()
    {
        Debug.Log("Quit requested");
        Application.Quit();
        
    }
}


    using UnityEngine;
    using UnityEngine.SceneManagement;
    using System.Collections;
    using UnityEngine.UI;

    public class NumberWizards : MonoBehaviour {
	    // Use this for initialization
	    int max;
	    int min;
	    int guess;
        public int maxGuess;
        public Text text;
        public Text counter;

	    void Start () {
        
		    StartGame();
	    }

        void StartGame()
        {
            maxGuess = 10;
            max = 1000;
            min = 1;
            guess = (int)Random.Range(min, max + 1);
            text.text = guess.ToString();
            counter.text ="Guesses Remaining: "+ maxGuess.ToString();    


    }

    public void GuessLower(){
        max = guess;
        NextGuess();
    }

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

	void NextGuess () {
        if (maxGuess == 0) {
            SceneManager.LoadScene("Win");
        }
        guess = (int)Random.Range(min, max+1);
        text.text = guess.ToString();
        maxGuess--;
        counter.text = "Guesses Remaining: " + maxGuess.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject exitMenuCanvas;
    public bool exitApplication;

    public int playerLives;

    public int playerHealth;


    public void NewGame()
    {

        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);

        PlayerPrefs.SetInt("CurrentScore", 0);

        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
        PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);

        SceneManager.LoadScene(2);
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);

        PlayerPrefs.SetInt("CurrentScore", 0);

        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
        PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);

        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        SceneManager.LoadScene(4);
    }
    
    public void Credits()
    {
        SceneManager.LoadScene(5);
    }

    public void Quit()
    {
        exitApplication = true;
    }



    public void No()
    {
        exitApplication = false;
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void QuitGame()
    {
       
        
       
        {
            exitMenuCanvas.SetActive(true);
            Time.timeScale = 0f;

        }


    }


    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (exitApplication)
        {
            exitMenuCanvas.SetActive(true);
            Time.timeScale = 0f;

        }
        else
        {
            exitMenuCanvas.SetActive(false);
            Time.timeScale = 1f;

        }

     



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseConditions : MonoBehaviour
{
    //loseScreenUI
    public GameObject loseScreenUI;
    //winScreenUI
    public GameObject winScreenUI;
    //pauseMenuUI
    public GameObject pauseMenuUI;

    //bool to set so that the player cannot pause during the win or lose screen
    public static bool canPause;
    private bool playerLost;
    private bool isPaused;

    void Start()
    {
        winScreenUI.SetActive(false);
        loseScreenUI.SetActive(false);
        canPause = true;
        playerLost = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //condition for losing the game
        if(HealthScript.health <= 0 && playerLost == false)
        {
            Time.timeScale = 0f;
            
            //set the loseScreen to become active
            playerLost = true;
            loseScreenUI.SetActive(true);
        }

        //if the player has completed the level
        if(WaveSpawner.playerWon == true && HealthScript.health > 0)
        {
            Time.timeScale = 0f;
            
            winScreenUI.SetActive(true);
        }

        //check to see if the user has pressed the esc key
        if (WaveSpawner.playerWon == false && playerLost == false && isPaused == false && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        else if(WaveSpawner.playerWon == false && playerLost == false && isPaused == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    public void RetryButton()
    {
        //retry the level the user is currently on
        loseScreenUI.SetActive(false);
        CurrencyScript.currency = 500;
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        //send the user back to the main menu
        Time.timeScale = 1f;
        Debug.Log("Attempting to quit");
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}

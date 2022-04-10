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

    //bool to set so that the player cannot pause during the win or lose screen
    public static bool canPause;

    void Start()
    {
        winScreenUI.SetActive(false);
        loseScreenUI.SetActive(false);
        canPause = true;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //condition for losing the game
        if(HealthScript.health <= 0)
        {
            Time.timeScale = 0f;
            //set the loseScreen to become active
            loseScreenUI.SetActive(true);
        }
    }

    public void RetryButton()
    {
        //retry the level the user is currently on
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        //send the user back to the main menu
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

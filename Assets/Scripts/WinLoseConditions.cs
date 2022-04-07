using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseConditions : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //condition for losing the game
        if(HealthScript.health <= 0)
        {
            Time.timeScale = 0f;
        }
    }
}

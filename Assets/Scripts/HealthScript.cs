using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    //static int for the overall health of the player
    public static int health = 100;
    public Text Health;

    // Update is called once per frame
    void Update()
    {
        Health.text = "Health: " + health;    
    }
}

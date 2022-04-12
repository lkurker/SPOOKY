using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    //static int for the overall health of the player
    public static int health = 100;
    public Text Health;
    public GameObject fullHeart;
    public GameObject threeFourthHeart;
    public GameObject halfHeart;
    public GameObject oneFourthHeart;
    public GameObject deadHeart;

    void Start()
    {
        health = 100;

        //set each heart image except for the first to false
        fullHeart.SetActive(true);
        threeFourthHeart.SetActive(false);
        halfHeart.SetActive(false);
        oneFourthHeart.SetActive(false);
        deadHeart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Health.text = "" + health;

        //series of if statements to set the heart images to true and false
        if(health <= 75 && health > 50)
        {
            fullHeart.SetActive(false);
            threeFourthHeart.SetActive(true);
            halfHeart.SetActive(false);
            oneFourthHeart.SetActive(false);
            deadHeart.SetActive(false);
        }
        else if(health <= 50 && health > 25)
        {
            fullHeart.SetActive(false);
            threeFourthHeart.SetActive(false);
            halfHeart.SetActive(true);
            oneFourthHeart.SetActive(false);
            deadHeart.SetActive(false);
        }
        else if(health <= 25 && health > 0)
        {
            fullHeart.SetActive(false);
            threeFourthHeart.SetActive(false);
            halfHeart.SetActive(false);
            oneFourthHeart.SetActive(true);
            deadHeart.SetActive(false);

        }
        else if(health <= 0)
        {
            fullHeart.SetActive(false);
            threeFourthHeart.SetActive(false);
            halfHeart.SetActive(false);
            oneFourthHeart.SetActive(false);
            deadHeart.SetActive(true);
        }
    }
}

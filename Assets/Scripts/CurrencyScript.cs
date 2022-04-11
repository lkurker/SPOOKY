using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyScript : MonoBehaviour
{
    //a static int variable that will keep track of our current currency
    public static int currency = 5000;
    public Text moneyText;
    


    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + currency;
    }
}

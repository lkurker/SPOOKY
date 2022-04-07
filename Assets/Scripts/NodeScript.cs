using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    //we will be using this color variable so that if we end up changing the material of our nodes, we won't need to hard code the change
    private Color startColor;
    public Color hoverColor;
    public Color occupiedColor;

    public static bool draggingTower;
    private bool towerPlaced = false;

    //array of Gameobjects to place our four towers in
    public GameObject[] towers;
    private GameObject tower;

    private Renderer rend;
    public Vector3 offset;
    private Vector3 towerPosition;

    //static int to determine which of the towers to place
    public static int towerOrder;
    //price of the current tower
    public static int currentTowerPrice;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        //setting the tower position to this nodes position plus the offset defined by us
        towerPosition = this.transform.position + offset;
        
    }




    void OnMouseEnter()
    {
        //calls if the node is not occupied by a tower
        if(towerPlaced == false)
        {
            rend.material.color = hoverColor;
        }

        //calls if the node IS occupied by a tower
        else if(towerPlaced == true)
        {
            rend.material.color = occupiedColor;
        }
        
        
    }

    void OnMouseOver()
    {
        if (!Input.GetMouseButton(0) && draggingTower == true && towerPlaced == false)
        {
            
            //check to see if the player can afford to buy the tower
            if ((CurrencyScript.currency - currentTowerPrice) >= 0)
            {
                //CurrencyScript.currency = CurrencyScript.currency - currentTowerPrice;
                tower = towers[towerOrder];
                CurrencyScript.currency = CurrencyScript.currency - currentTowerPrice;
                Instantiate(tower, towerPosition, this.transform.rotation);

                //setting the bool to true so that another tower cannot be placed on this node 
                towerPlaced = true;

            }
            

            
        }

        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBox : MonoBehaviour
{
    Vector3 downToCull = new Vector3(0,-5,0);
    public GameObject playerWhoOwnsThisBasket;
    public Text thisBasketScoreTXT;

    //reference to GUI canvas with HotItemsScores.cs attached
    public HotItemScores hotItems;

    int myScore = 0;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Check what object entered the basket area
    private void OnTriggerEnter(Collider other)
    {
        var objectName = other.transform.name;

        if(objectName.Contains("Pumpkin"))
        {
            // Score the pumpkin for the player
            other.transform.position += downToCull;
            // Check value of item through hotItems script
            myScore += hotItems.checkScoreOfItem("Pumpkin");
            thisBasketScoreTXT.text = playerWhoOwnsThisBasket.name + " Score: " + myScore;
        }
        else if(objectName.Contains("Mushroom"))
        {
            other.transform.position += downToCull;
            myScore += hotItems.checkScoreOfItem("Mushroom");
            thisBasketScoreTXT.text = playerWhoOwnsThisBasket.name + " Score: " + myScore;
        }
        else if(objectName.Contains("Egg"))
        {
            other.transform.position += downToCull;
            myScore += hotItems.checkScoreOfItem("Egg");
            thisBasketScoreTXT.text = playerWhoOwnsThisBasket.name + " Score: " + myScore;
        }
        else if(objectName.Contains("Turnip"))
        {
            other.transform.position += downToCull;
            myScore += hotItems.checkScoreOfItem("Turnip");
            thisBasketScoreTXT.text = playerWhoOwnsThisBasket.name + " Score: " + myScore;
        }
        else if(objectName.Contains("Carrot"))
        {
            other.transform.position += downToCull;
            myScore += hotItems.checkScoreOfItem("Carrot");
            thisBasketScoreTXT.text = playerWhoOwnsThisBasket.name + " Score: " + myScore;
        }
        else if(objectName.Contains("Chicken"))
        {
            other.transform.position += downToCull;
            myScore += hotItems.checkScoreOfItem("Chicken");
            thisBasketScoreTXT.text = playerWhoOwnsThisBasket.name + " Score: " + myScore;
        }
        else if(objectName.Contains("Potato"))
        {
            other.transform.position += downToCull;
            myScore += hotItems.checkScoreOfItem("Potato");
            thisBasketScoreTXT.text = playerWhoOwnsThisBasket.name + " Score: " + myScore;
        }
        else if(objectName.Contains("Radish"))
        {
            other.transform.position += downToCull;
            myScore += hotItems.checkScoreOfItem("Radish");
            thisBasketScoreTXT.text = playerWhoOwnsThisBasket.name + " Score: " + myScore;
        }
        else if(objectName.Contains("Tomato"))
        {
            other.transform.position += downToCull;
            myScore += hotItems.checkScoreOfItem("Tomato");
            thisBasketScoreTXT.text = playerWhoOwnsThisBasket.name + " Score: " + myScore;
        }

    }
}

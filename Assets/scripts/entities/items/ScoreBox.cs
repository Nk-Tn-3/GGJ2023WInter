using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBox : MonoBehaviour
{
    Vector3 downToCull = new Vector3(0,-5,0);
    public GameObject playerWhoOwnsThisBasket;
    public Text thisBasketScoreTXT;

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
            print(objectName);
            other.transform.position += downToCull;
            myScore += 1;
            thisBasketScoreTXT.text = playerWhoOwnsThisBasket.name + " Score: " + myScore;
        }
    }
}

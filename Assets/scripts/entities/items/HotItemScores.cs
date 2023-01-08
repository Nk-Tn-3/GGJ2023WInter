using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotItemScores : MonoBehaviour
{
    Dictionary<string, int> scoreValues;

    // Start is called before the first frame update
    void Start()
    {
        scoreValues = new Dictionary<string, int>()
        {
            {"Pumpkin", 1},
            {"Mushroom", 1},
            {"Egg", 1},
            {"Turnip", 1}
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int checkScoreOfItem(string itemName)
    {
        return scoreValues[itemName];
    }
}

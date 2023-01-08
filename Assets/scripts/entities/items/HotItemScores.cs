using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotItemScores : MonoBehaviour
{
    Dictionary<string, int> scoreValues;
    public Image hotGuiIMG;

    public Sprite carrotThumb;
    public Sprite potatoThumb;
    public Sprite raddishThumb;  
    public Sprite turnipThumb;
    public Sprite tomatoThumb;

    public Sprite pumpkinThumb;
    public Sprite mushroomThumb;
    public Sprite eggThumb;

    public Sprite chickenThumb;

    int IndexOfHotItem = 0;
    int IndexLastHot = 0;

    public float hotRate = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        scoreValues = new Dictionary<string, int>()
        {
            {"Carrot", 2},
            {"Potato", 1},
            {"Raddish", 1},
            {"Turnip", 1},
            {"Tomato", 1},

            {"Pumpkin", 2},
            {"Mushroom", 2},
            {"Egg", 2},

            {"Chicken", 2}
            
        };

        InvokeRepeating("randomizeHotItem", 0.0f, hotRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called from score baskets/crates to verify current value
    public int checkScoreOfItem(string itemName)
    {
        return scoreValues[itemName];
    }

    void randomizeHotItem()
    {
        IndexOfHotItem = Random.Range(0,9);

        switch (IndexLastHot)
        {
            case 0:
                scoreValues["Carrot"] = scoreValues["Carrot"] / 2;
                break;
            case 1:
                scoreValues["Potato"] = scoreValues["Potato"] / 2;
                break;
            case 2:
                scoreValues["Raddish"] = scoreValues["Raddish"] / 2;
                break;
            case 3:
                scoreValues["Turnip"] /= 2;
                break;
            case 4:
                scoreValues["Tomato"] /= 2;
                break;
            case 5:
                scoreValues["Pumpkin"] /= 2;
                break;
            case 6:
                scoreValues["Mushroom"] /= 2;
                break;
            case 7:
                scoreValues["Egg"] /= 2;
                break;
            case 8:
                scoreValues["Chicken"] /= 2;
                break;
        }

        switch (IndexOfHotItem)
        {
            case 0:
                scoreValues["Carrot"] = scoreValues["Carrot"] * 2;
                IndexLastHot = 0;
                hotGuiIMG.sprite = carrotThumb;
                break;
            case 1:
                scoreValues["Potato"] = scoreValues["Potato"] * 2;
                IndexLastHot = 1;
                hotGuiIMG.sprite = potatoThumb;
                break;
            case 2:
                scoreValues["Raddish"] = scoreValues["Raddish"] * 2;
                IndexLastHot = 2;
                hotGuiIMG.sprite = raddishThumb;
                break;
            case 3:
                scoreValues["Turnip"] = scoreValues["Turnip"] * 2;
                IndexLastHot = 3;
                hotGuiIMG.sprite = turnipThumb;
                break;
            case 4:
                scoreValues["Tomato"] = scoreValues["Tomato"] * 2;
                IndexLastHot = 4;
                hotGuiIMG.sprite = tomatoThumb;
                break;

            case 5:
                scoreValues["Pumpkin"] = scoreValues["Pumpkin"] * 2;
                IndexLastHot = 5;
                hotGuiIMG.sprite = pumpkinThumb;
                break;
            case 6:
                scoreValues["Mushroom"] = scoreValues["Mushroom"] * 2;
                IndexLastHot = 6;
                hotGuiIMG.sprite = mushroomThumb;
                break;
            case 7:
                scoreValues["Egg"] = scoreValues["Egg"] * 2;
                IndexLastHot = 7;
                hotGuiIMG.sprite = eggThumb;
                break;

            case 8:
                scoreValues["Chicken"] = scoreValues["Chicken"] * 2;
                IndexLastHot = 8;
                hotGuiIMG.sprite = chickenThumb;
                break;

            default:
                hotGuiIMG.sprite = null;
                break;
        }
    }
}

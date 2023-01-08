using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerColor /*: MonoBehaviour //added mono so I could use the script*/
{
    private Player player;



    private CharacterColor color;

    SkinnedMeshRenderer renderer;


    public PlayerColor(Player player,CharacterColor color)
    {

        this.player = player;
        renderer = player.GetComponentInChildren<SkinnedMeshRenderer>();
        this.color = color;
    
    }

    public void Initialize()
    {
        //0 Pants, 1 Cloth, 6 Hat, 3 Hair
        renderer.materials[0].color = color.colors[1];
        renderer.materials[1].color = color.colors[0];
        renderer.materials[3].color = color.colors[2];
        renderer.materials[6].color = color.colors[3];
    }

}

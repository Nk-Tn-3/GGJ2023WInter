using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: MFyfe
// Attach me to an empty gameobject to act as the spawner!
public class ItemSpawner : MonoBehaviour
{
    //Set the item to be spawned via inspector
    public GameObject itemToSpawn;

    int thisItemCount = 0;
    public int thisItemMax = 1;
    public float spawnRate = 1.0f;

    List<GameObject> itemList = new List<GameObject>();


    void Start()
    {
        //Call spawnItem in 1 second, and every second afterwards forever
        InvokeRepeating("SpawnItem", 1.0f, spawnRate);
    }


    void Update()
    {
        //cull plane items that fall out of map
        foreach(GameObject g in itemList)
        {
            if(g.transform.position.y < -5)
            {
                itemList.Remove(g);
                Destroy(g);
                thisItemCount--;
                break;
            }
        }
        
    }


    // Spawn an item if we aren't at the max yet
    void SpawnItem()
    {
        if(thisItemCount < thisItemMax)
        {
            itemList.Add(Instantiate(itemToSpawn, this.transform.position, Quaternion.identity));
            thisItemCount++;
        }
    }
}

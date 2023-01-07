using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to the item/character that will do a random walk pattern
public class ItemWander : MonoBehaviour
{
    float x = 0;
    float y = 0;
    float z = 0;
    Vector3 targetDestination = new Vector3(0,0,0);

    public GameObject parentObject;
    public float speed = 1.0f;
    
    void Start()
    {
        InvokeRepeating("RandomWander", 1.0f, 2.0f);
    }

   
    void Update()
    {
        //attempt to walk to it
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(parentObject.transform.position, targetDestination, step);
    }

    void RandomWander()
    {
        //choose a new direction / target
        x = parentObject.transform.position.x + Random.Range(-3.0f, 3.0f);
        z = parentObject.transform.position.z + Random.Range(-3.0f, 3.0f);
        targetDestination = new Vector3(x,y,z);
    }
}

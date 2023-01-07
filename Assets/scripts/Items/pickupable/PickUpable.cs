using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpable : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponentInParent<Player>();
        
        if (player != null)
        {
            Debug.Log("Picking up"+ gameObject.name);
            player.PickUp();
            Destroy(gameObject);
        }
    }
}

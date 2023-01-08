using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PickUpable : MonoBehaviour
{
    Rigidbody rb;
    Collider collider;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider= GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponentInParent<Player>();
        
        if (player != null)
        {
            Debug.Log("Picking up"+ gameObject.name);
            player.PickUp(gameObject);
            disableCols();
         
        }
    }

    public void setNewPartent(Transform parent)
    {
        transform.parent = parent;
    }

    private void disableCols()
    {
        rb.isKinematic = true;
        collider.enabled = false;
    }


    private void EnableColls()
    {
        rb.isKinematic = false;
        collider.enabled = true;
    }



    public void Throw(Vector3 dir)
    {
        EnableColls();
        transform.parent = null;
        rb.AddForce(dir,ForceMode.Impulse);
    }
}

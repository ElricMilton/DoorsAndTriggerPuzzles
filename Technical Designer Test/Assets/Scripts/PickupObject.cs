using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public Collider col;

    Vector3 itemRespawnPos;

    public KeyType keyType;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        col = gameObject.GetComponent<Collider>();
        itemRespawnPos = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            print("triggering on correct layers");
            PlayerItemManager itemManager = other.GetComponent<PlayerItemManager>();
            if (itemManager.handsFull == false)
            {
                //Pickup object
                itemManager.PickUp(gameObject.GetComponent<Collider>());

                if (keyType != null)
                {
                    itemManager.heldKeyType = keyType;
                }
            }
        }
    }

    public void DisintegrateObject()
    {
        Destroy(gameObject, 1f);
    }
}

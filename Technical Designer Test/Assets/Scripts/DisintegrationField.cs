using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisintegrationField : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<PickupObject>().DisintegrateObject();
        }
        if (other.gameObject.layer == 6)
        {
            PlayerItemManager itemManager = other.gameObject.GetComponent<PlayerItemManager>();
            if (itemManager.itemHeld != null)
            {
                itemManager.DisintegrateHeldObject();
            }
        }
        if (other.gameObject.layer == 8)
        {
            other.gameObject.GetComponent<BoulderRoll>().DisintegrateObject();
        }
    }
}

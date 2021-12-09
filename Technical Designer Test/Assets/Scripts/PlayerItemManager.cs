using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemManager : MonoBehaviour
{
    [HideInInspector] public KeyType heldKeyType;
    [HideInInspector] public PickupObject itemHeld;
    public GameObject ItemHolderObj;
    [HideInInspector] public bool handsFull = false;

    public GameObject idleHands;
    public GameObject raisedHands;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Drop held object
            if(itemHeld != null)
            {
                DropItem();
            }
        }
    }

    public void PickUp(Collider other)
    {
        itemHeld = other.GetComponent<PickupObject>();
        itemHeld.transform.SetParent(ItemHolderObj.transform);
        itemHeld.transform.position = ItemHolderObj.transform.position;
        itemHeld.col.enabled = false;
        itemHeld.rb.isKinematic = true;
        itemHeld.rb.freezeRotation = true;
        handsFull = true;

        raisedHands.SetActive(true);
        idleHands.SetActive(false);
    }

    public void DropItem()
    {
        itemHeld.gameObject.transform.SetParent(null);
        itemHeld.rb.isKinematic = false;
        itemHeld.col.enabled = true;
        itemHeld.rb.freezeRotation = false;

        heldKeyType = null;
        itemHeld = null;

        raisedHands.SetActive(false);
        idleHands.SetActive(true);

        //Make sure the player doesn't immediately pick the object back up
        StartCoroutine(PickupCooldown());
    }

    IEnumerator PickupCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        handsFull = false;
    }

    public void DisintegrateHeldObject()
    {
        itemHeld.gameObject.transform.SetParent(null);

        //itemHeld.rb.isKinematic = false;
        //itemHeld.col.enabled = true;
        itemHeld.rb.freezeRotation = false;
        itemHeld.rb.useGravity = false;

        heldKeyType = null;

        //Record the object to disintegrate later
        PickupObject itemToDisintigrate;
        itemToDisintigrate = itemHeld;

        itemHeld = null;

        //Play drop animation / set hands to idle
        raisedHands.SetActive(false);
        idleHands.SetActive(true);

        //Make sure the player doesn't immediately pick the object back up
        StartCoroutine(PickupCooldown());

        //Destroy the object
        itemToDisintigrate.DisintegrateObject();
    }
}

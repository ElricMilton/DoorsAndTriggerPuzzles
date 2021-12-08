using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : BasicDoor
{
    bool locked = true;
    public KeyType keyNeededToOpen;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            if (locked)
            {
                //If the player is holding the correct key, unlock the door.
                PlayerItemManager itemManager = other.GetComponent<PlayerItemManager>();
                if (itemManager.heldKeyType == keyNeededToOpen)
                {
                    itemManager.itemHeld.NormalDestroy();
                    itemManager.handsFull = false;
                    itemManager.heldKeyType = null;
                    itemManager.itemHeld = null;
                    Trigger();
                    locked = false;
                    itemManager.raisedHands.SetActive(false);
                    itemManager.idleHands.SetActive(true);
                }
            }
            else
                Trigger();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Finished();
        }
    }
    
    public override void Trigger()
    {
        base.Trigger();

        Door.localPosition = OpenPosition;

    }

    public override void Finished()
    {
        base.Finished();

        Door.localPosition = Vector3.zero;
    }

}

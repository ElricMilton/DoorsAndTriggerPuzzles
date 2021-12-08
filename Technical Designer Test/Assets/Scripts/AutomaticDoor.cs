using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : BasicDoor
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
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

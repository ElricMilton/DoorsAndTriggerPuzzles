using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDoor : MonoBehaviour
{
    public Vector3 OpenPosition => openPosition;
    public bool IsOpen => isOpen;
    public Transform Door => door;
    [SerializeField]
    Transform door;

    [SerializeField]
    Vector3 openPosition;

    bool isOpen;

    public virtual void Trigger()
    {
        door.localPosition = openPosition;
        isOpen = true;

    }

    public virtual void Finished()
    {
        door.localPosition = Vector3.zero;
        isOpen = false;
    }

    public virtual void Toggle()
    {
        if (!isOpen)
        {
            Trigger();
        }
        else if (isOpen)
        {
            Finished();
        }
    }
}
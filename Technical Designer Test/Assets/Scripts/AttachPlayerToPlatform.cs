using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayerToPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            other.transform.parent = gameObject.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            other.transform.parent = null;
        }
    }
}

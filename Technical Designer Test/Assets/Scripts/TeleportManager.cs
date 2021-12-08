using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{

    public bool triggered = false;

    public void Teleport(Collider other, Vector3 destination)
    {
        other.gameObject.GetComponent<CharacterController>().transform.position = destination;
        StartCoroutine(TeleportCooldown(other));
    }

    IEnumerator TeleportCooldown(Collider other)
    {
        yield return new WaitForSeconds(0.1f);
        triggered = false;
    }
}

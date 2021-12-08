using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    TeleportManager teleportManager;
    [SerializeField] GameObject destinationTeleporter;
    Vector3 destination;

    private void Awake()
    {
        teleportManager = gameObject.GetComponentInParent<TeleportManager>();
        destination = destinationTeleporter.gameObject.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (teleportManager.triggered == false && other.gameObject.layer == 6)
        {
            teleportManager.triggered = true;
            teleportManager.Teleport(other, destination);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            //teleportManager.triggered = false;
        }
    }
}

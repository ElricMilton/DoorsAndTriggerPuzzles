using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderRoll : MonoBehaviour
{
    Rigidbody rb;
    public float force;
    bool triggered = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            other.gameObject.GetComponent<Player>().KillPlayer();
        }
    }

    public void Roll()
    {
        if (!triggered)
        {
            rb.AddForce(Vector3.forward * force);
        }
    }
}

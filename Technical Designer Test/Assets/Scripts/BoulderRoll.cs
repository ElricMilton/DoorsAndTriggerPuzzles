using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderRoll : MonoBehaviour
{
    Rigidbody rb;
    public float force;
    bool triggered = false;

    Material material;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        material = GetComponent<MeshRenderer>().material;
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

    public void DisintegrateObject()
    {
        if (material.GetFloat("_Amount") < 1)
        {
            InvokeRepeating("IncreaseDissolve", 0f, 0.05f);
        }
        Destroy(gameObject, 1f);
    }
    void IncreaseDissolve()
    {
        float amount = material.GetFloat("_Amount");
        material.SetFloat("_Amount", amount += 0.05f);
    }
}

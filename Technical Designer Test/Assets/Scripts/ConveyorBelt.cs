using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float conveySpeed;
    Rigidbody rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 pos= rBody.position;
        rBody.position += transform.forward * conveySpeed * Time.fixedDeltaTime;
        rBody.MovePosition(pos);
    }
}

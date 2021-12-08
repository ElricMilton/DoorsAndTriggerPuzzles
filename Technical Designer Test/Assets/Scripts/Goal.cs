using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    Player player;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            player = other.GetComponent<Player>();
            player.transform.position = transform.position;
            player.Movement.enabled = false;
        }
    }
}

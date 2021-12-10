using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisintegrationField : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.KillPlayer();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    Animator anim;
    Collider col;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        col = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            StartCoroutine(Fall());
        }
    }


    IEnumerator Fall()
    {
        anim.Play("FallingPlatform");
        yield return new WaitForSeconds(1f);
        col.enabled = false;
        Destroy(gameObject, 2f);
    }
}

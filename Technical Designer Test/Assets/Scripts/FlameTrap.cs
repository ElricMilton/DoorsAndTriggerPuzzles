using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : MonoBehaviour
{
    Collider col;
    public GameObject flameFX;
    bool isActive = false;
    public float onDelay;
    public float offDelay;
    public float cooldown;
    bool isOnCooldown = false;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            if (other.gameObject.layer == 6)
            {
                other.gameObject.GetComponent<Player>().KillPlayer();
            }
            if (other.gameObject.layer == 7)
            {
                other.gameObject.GetComponent<PickupObject>().DisintegrateObject();
            }
        }
    }

    public void TurnOnFlames()
    {
        if (!isActive)
        {
            isOnCooldown = true;
            StopCoroutine(OffDelay());
            StopCoroutine(OnDelay());
            StartCoroutine(OnDelay());
        }
    }

    public void TurnOffFlames()
    {
        if (isActive)
        {
            StopCoroutine(OffDelay());
            StopCoroutine(OnDelay());
            StartCoroutine(OffDelay());
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator OnDelay()
    {
        yield return new WaitForSeconds(onDelay);
        col.enabled = true;
        flameFX.SetActive(true);
        isActive = true;
    }

    IEnumerator OffDelay()
    {
        yield return new WaitForSeconds(offDelay);
        col.enabled = false;
        flameFX.SetActive(false);
        isActive = false;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
    }
}

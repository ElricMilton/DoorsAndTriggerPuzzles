using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedFlameTrap : MonoBehaviour
{
    Collider col;
    public GameObject flameFX;
    bool isActive = false;
    public float cooldown;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    private void Start()
    {
        InvokeRepeating("TurnOnFlames", cooldown, cooldown*2);
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


    void TurnOnFlames()
    {
        col.enabled = true;
        flameFX.SetActive(true);
        isActive = true;
        StartCoroutine(OffAfterX());
    }

    IEnumerator OffAfterX()
    {
        yield return new WaitForSeconds(cooldown);
        col.enabled = false;
        flameFX.SetActive(false);
        isActive = false;
    }
}

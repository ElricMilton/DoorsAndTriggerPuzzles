using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject spawnFX;
    void Start()
    {
        StartCoroutine(TurnOffSpawnFX());
    }

    IEnumerator TurnOffSpawnFX()
    {
        yield return new WaitForSeconds(1.5f);
        spawnFX.SetActive(false);
    }
}

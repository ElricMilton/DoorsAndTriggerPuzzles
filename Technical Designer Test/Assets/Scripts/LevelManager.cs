using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] PlayerData player;
    [SerializeField] float spawnDelay;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(SpawnPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetLevel();
        }
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(player.playerObject, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

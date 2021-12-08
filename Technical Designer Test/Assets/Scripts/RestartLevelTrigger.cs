using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<PickupObject>().ResetItem();
        }
    }
}

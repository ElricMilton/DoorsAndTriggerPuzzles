using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public static Player Instance {get; private set;}
    public PlayerMovement Movement => movement;
    public CharacterController Controller;

    public GameObject model;
    Material mat;
    float emissionFlickerSpeed = 0.1f;

    [SerializeField]
    PlayerMovement movement;

    void Start()
    {
        Instance = this;
        mat = model.GetComponent<MeshRenderer>().material;
        mat.DisableKeyword("_EMISSION");
    }

    public void KillPlayer()
    {
        StartCoroutine(DeathEvents());
    }

    IEnumerator DeathEvents()
    {
        movement.enabled = false;
        mat.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(emissionFlickerSpeed);
        mat.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(emissionFlickerSpeed);
        mat.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(emissionFlickerSpeed);
        mat.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(emissionFlickerSpeed);
        mat.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(emissionFlickerSpeed);
        mat.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(emissionFlickerSpeed);
        mat.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(emissionFlickerSpeed);
        mat.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(emissionFlickerSpeed);
        mat.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(emissionFlickerSpeed);
        mat.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(emissionFlickerSpeed);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

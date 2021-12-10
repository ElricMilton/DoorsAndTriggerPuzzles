using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public Collider col;

    Vector3 itemRespawnPos;

    public KeyType keyType;

    MeshRenderer meshRenderer;
    Material material;

    PlayerItemManager itemManager = null;

    private void Start()
    {
        meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        Material tempMat = meshRenderer.material;
        material = new Material(tempMat);
        meshRenderer.material = material;
        rb = gameObject.GetComponent<Rigidbody>();
        col = gameObject.GetComponent<Collider>();
        itemRespawnPos = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            itemManager = other.GetComponent<PlayerItemManager>();
            if (itemManager.handsFull == false)
            {
                //Pickup object
                itemManager.PickUp(gameObject.GetComponent<Collider>());

                if (keyType != null)
                {
                    itemManager.heldKeyType = keyType;
                }
            }
        }
    }

    public void DisintegrateObject()
    {
        if (material.GetFloat("_Amount") < 1)
        {
            InvokeRepeating("IncreaseDissolve", 0f, 0.05f);
        }
        Destroy(gameObject, 1f);
    }

    void IncreaseDissolve()
    {
        float amount = material.GetFloat("_Amount");
        material.SetFloat("_Amount", amount += 0.05f);
    }

    public void NormalDestroy()
    {
        Destroy(gameObject, 0.2f);
    }

    public void ResetItem()
    {
        gameObject.transform.SetParent(null);
        rb.isKinematic = false;
        col.enabled = true;
        rb.freezeRotation = false;
        transform.position = itemRespawnPos;
        itemManager.heldKeyType = null;
        itemManager.itemHeld = null;
        itemManager.raisedHands.SetActive(false);
        itemManager.idleHands.SetActive(true);
    }
}

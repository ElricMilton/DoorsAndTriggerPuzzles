using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] BasicDoor door1;
    [SerializeField] BasicDoor door2;
    [SerializeField] GameObject plate;

    public float pressedPosition;
    Vector3 unpressedPos;
    public bool isPressed = false;
    public float triggerWeight;
    public float currentWeight;

    [SerializeField] Material defaultMat;
    [SerializeField] Material pressedMat;
    MeshRenderer mRenderer;

    private void Awake()
    {
        mRenderer = plate.GetComponentInChildren<MeshRenderer>();
        door1.Toggle();
        unpressedPos = plate.transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<WeightedObject>() != null)
        {
            currentWeight += other.gameObject.GetComponent<WeightedObject>().weight;
            if (currentWeight >= triggerWeight && isPressed == false)
            {
                Trigger();
                door1.Toggle();
                door2.Toggle();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<WeightedObject>() != null)
        {
            currentWeight -= other.gameObject.GetComponent<WeightedObject>().weight;
            if (currentWeight < triggerWeight && isPressed == true)
            {
                Finished();
                door1.Toggle();
                door2.Toggle();
            }
        }
    }

    public virtual void Trigger()
    {
        plate.transform.localPosition = new Vector3 (0, pressedPosition, 0);
        isPressed = true;
        mRenderer.material = pressedMat;
    }

    public virtual void Finished()
    {
        plate.transform.localPosition = unpressedPos;
        isPressed = false;
        mRenderer.material = defaultMat;
    }
}

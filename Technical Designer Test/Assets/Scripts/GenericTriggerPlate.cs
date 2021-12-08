using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericTriggerPlate : MonoBehaviour
{
    [SerializeField] GameObject plate;

    public UnityEvent triggeredEvent;

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
            }
        }
    }

    public virtual void Trigger()
    {
        plate.transform.localPosition = new Vector3(0, pressedPosition, 0);
        isPressed = true;
        triggeredEvent.Invoke();
        mRenderer.material = pressedMat;
    }

    public virtual void Finished()
    {
        plate.transform.localPosition = unpressedPos;
        isPressed = false;
        mRenderer.material = defaultMat;
    }
}

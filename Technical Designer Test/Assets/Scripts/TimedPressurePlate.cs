using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPressurePlate : MonoBehaviour
{
    [SerializeField] BasicDoor timedDoor;
    [SerializeField] GameObject plate;

    public float secondsToClose;

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
                timedDoor.Trigger();
                StopAllCoroutines();
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
                StartCoroutine(CloseAfterSeconds());
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

    IEnumerator CloseAfterSeconds()
    {
        yield return new WaitForSeconds(secondsToClose);
        timedDoor.Finished();
    }
}

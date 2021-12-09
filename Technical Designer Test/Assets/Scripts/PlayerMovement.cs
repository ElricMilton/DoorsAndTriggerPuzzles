using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController playerController;
    public float movementSpeed;
    
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (input.sqrMagnitude > 1)
        {
            input.Normalize();
        }

        Vector3 movement = new Vector3(input.x * movementSpeed, -9.8f, input.y * movementSpeed) * Time.deltaTime;
        this.playerController.Move(movement);

        Vector3 rotation = new Vector3(movement.x, 0, movement.z);
        if(rotation.magnitude > 0.005f)
        {
            this.playerController.transform.rotation = Quaternion.LookRotation(rotation);
        }
    }
}

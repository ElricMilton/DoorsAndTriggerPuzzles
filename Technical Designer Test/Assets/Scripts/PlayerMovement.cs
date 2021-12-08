using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController playerController;
    
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (input.sqrMagnitude > 1)
        {
            input.Normalize();
        }

        Vector3 movement = new Vector3(input.x * 8f, -9.8f, input.y * 8f) * Time.deltaTime;
        this.playerController.Move(movement);

        Vector3 rotation = new Vector3(movement.x, 0, movement.z);
        if(rotation.magnitude > 0.005f)
        {
            this.playerController.transform.rotation = Quaternion.LookRotation(rotation);
        }
    }
}

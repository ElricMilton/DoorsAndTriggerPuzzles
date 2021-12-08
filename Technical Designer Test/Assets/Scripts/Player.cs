using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {get; private set;}
    public PlayerMovement Movement => movement;
    public CharacterController Controller;

    [SerializeField]
    PlayerMovement movement;

    void Start()
    {
        Instance = this;
    }

}

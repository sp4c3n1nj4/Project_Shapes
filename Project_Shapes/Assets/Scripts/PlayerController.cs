using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float slow = 1;
    public CharacterController player;
    public PlayerInputActions inputActions;

    private InputAction move;
    private Vector3 directionInput;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = inputActions.Player.Move;
        move.Enable();
    }

    //update physics of player
    private void FixedUpdate()
    {
        MovePlayer();
    }

    //move player in fixed update
    private void MovePlayer()
    {
        player.Move(directionInput * (Time.fixedDeltaTime * speed * slow));
    }

    //get player input
    private void Update()
    {
        directionInput = MovementInput();
    }

    //convert player input to vector3
    private Vector3 MovementInput()
    {
        Vector3 input = Vector3.zero;

        //print(move.ReadValue<Vector2>());

        input.x = move.ReadValue<Vector2>().x;
        input.z = move.ReadValue<Vector2>().y;

        //normalize in case of diagonal movement direction
        if (input.magnitude > 1)
            input = input.normalized;

        return input;
    }
}

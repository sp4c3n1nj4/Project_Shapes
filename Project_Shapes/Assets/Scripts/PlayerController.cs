using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public CharacterController player;

    private Vector3 directionInput;

    //update physics of player
    private void FixedUpdate()
    {
        MovePlayer();
        //todo: fake gravity - just keep it flat
    }

    //move player in fixed update
    private void MovePlayer()
    {
        player.Move(directionInput * (Time.fixedDeltaTime * speed));
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

        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        //normalize in case of diagonal movement direction
        if (input.magnitude > 1)
            input = input.normalized;

        return input;
    }
}

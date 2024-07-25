using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerAction : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerJump jump;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        jump = GetComponent<PlayerJump>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement.SetDirectionX(context.ReadValue<float>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
            jump.StartJump();
    }
}

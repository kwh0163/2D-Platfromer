using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerAction : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerJump jump;
    private PlayerSlide slide;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        jump = GetComponent<PlayerJump>();
        slide = GetComponent<PlayerSlide>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            slide.CancelSlide();
        }
        movement.SetDirectionX(context.ReadValue<float>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
            jump.StartJump();
    }
    public void OnSlide(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            slide.ActiveSlide();
        }
        if (context.canceled)
        {
            //slide.CancelSlide();
        }
    }
}

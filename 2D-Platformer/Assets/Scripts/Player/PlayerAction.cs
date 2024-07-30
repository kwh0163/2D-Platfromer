using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerJump jump;
    [SerializeField] private PlayerSlide slide;
    [SerializeField] private PlayerInteract interact;

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
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            interact.OnInteract();
        }
    }
}

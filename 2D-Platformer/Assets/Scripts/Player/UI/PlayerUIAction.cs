using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUIAction : MonoBehaviour
{
    private PlayerTextBox textBox;

    private void Awake()
    {
        textBox = GetComponent<PlayerTextBox>();
    }

    public void OnSkip(InputAction.CallbackContext context)
    {
        if(context.started)
            textBox.OnSkipText();
    }
}

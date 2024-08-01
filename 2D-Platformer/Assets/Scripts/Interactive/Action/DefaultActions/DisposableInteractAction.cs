using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DisposableInteractAction : InteractAction
{
    public override bool CheckInteractable()
    {
        if (isInteractable)
            isInteractable = false;
        else
            return false;
        return true;
    }
    public void ResetAction()
    {
        isInteractable = true;
    }
}

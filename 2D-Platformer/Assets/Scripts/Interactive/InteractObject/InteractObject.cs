using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractObject : MonoBehaviour, Interact
{
    private InteractOutLine outLine;
    private InteractAction action;
    private void Awake()
    {
        outLine = GetComponent<InteractOutLine>();
        action = GetComponent<InteractAction>();
    }
    public void CancelInteract()
    {
        outLine.OffOutLine();
    }

    public virtual UnityAction GetInteractAction()
    {
        if (!action.CheckInteractable())
            return null;

        outLine.OnOutLine();
        return action.Action;
    }
}

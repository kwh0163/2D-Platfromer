using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractObject : MonoBehaviour, Interact
{
    private InteractAction action;

    public bool IsInteractable => action.CheckInteractable();

    private void Awake()
    {
        action = GetComponent<InteractAction>();
    }

    public UnityAction<GameObject> GetInteractAction()
    {
        if (!action.CheckInteractable())
            return ((_gameObject) => { });

        return action.Action;
    }
}

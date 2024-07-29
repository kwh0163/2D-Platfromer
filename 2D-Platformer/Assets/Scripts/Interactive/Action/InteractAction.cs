using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractAction : MonoBehaviour
{
    protected bool isInteractable;
    public virtual bool CheckInteractable()
    {
        return isInteractable;
    }
    public abstract void Action();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CountableInteractAction : InteractAction
{
    [SerializeField] private int maxCount;
    private int currentCount;
    private void Start()
    {
        currentCount = 0;
    }
    public override bool CheckInteractable()
    {
        if (isInteractable)
        {
            currentCount++;
            isInteractable = currentCount < maxCount;
            return true;
        }
        return false;
    }
}

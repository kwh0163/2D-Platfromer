using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CountableInteractAction : InteractAction
{
    [SerializeField] protected int itemGetIndex = -1;
    protected int maxCount;
    protected int currentCount;
    protected override void Start()
    {
        base.Start();
        currentCount = 0;
    }
    public override bool CheckInteractable()
    {
        if (isInteractable)
        {
            isInteractable = currentCount < maxCount;
            return true;
        }
        return false;
    }
}

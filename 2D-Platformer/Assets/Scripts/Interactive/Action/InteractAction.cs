using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractAction : MonoBehaviour
{
    [SerializeField] private Vector3 guideOffset;
    public Vector3 GetGuidePosition() {
        return transform.position + guideOffset;
    }

    protected bool isInteractable;
    protected virtual void Start()
    {
        isInteractable = true;
    }
    public virtual bool CheckInteractable()
    {
        return isInteractable;
    }
    public abstract void Action(GameObject _gameObject);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractAction : MonoBehaviour
{
    [SerializeField] private Vector3 guideOffset;
    [SerializeField] protected Item item;
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
    protected void GiveItem(GameObject _gameObject)
    {
        _gameObject.GetComponent<PlayerInvectory>().AddItem(item);
    }
    public abstract void Action(GameObject _gameObject);
}

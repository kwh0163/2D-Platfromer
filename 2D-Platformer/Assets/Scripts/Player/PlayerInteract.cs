using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    private Interact currentInteract;
    private UnityEvent currentEvent;

    private void Awake()
    {
        if(currentEvent == null)
            currentEvent = new UnityEvent();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Interact interact))
        {
            RemoveInteract();
            AddInteract(interact);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interact interact))
        {
            if (interact == currentInteract)
                RemoveInteract();
        }
    }
    private void AddInteract(Interact _interact)
    {
        currentInteract = _interact;
        currentEvent.AddListener(_interact.GetInteractAction());
    }
    private void RemoveInteract()
    {
        currentInteract?.CancelInteract();
        currentEvent.RemoveAllListeners();
    }

    public void OnInteract()
    {
        currentEvent.Invoke();
    }
}

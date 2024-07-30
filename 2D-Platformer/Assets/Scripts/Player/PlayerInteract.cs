using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    public PlayerTextBox textBox;

    private Interact currentInteract;
    private UnityEvent<GameObject> currentEvent;

    private void Awake()
    {
        if(currentEvent == null)
            currentEvent = new UnityEvent<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interact interact))
        {
            RemoveInteract();
            AddInteract(interact);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interact interact))
        {
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
        currentEvent.RemoveAllListeners();
    }

    public void OnInteract()
    {
        currentEvent?.Invoke(gameObject);
        if(currentInteract != null && !currentInteract.IsInteractable)
            RemoveInteract();
    }
}

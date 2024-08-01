using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    public PlayerTextBox textBox;

    private InteractGuide guide;

    private InteractAction currentAction;
    private UnityEvent<GameObject> currentEvent;

    private void Awake()
    {
        guide = GetComponent<InteractGuide>();

        if(currentEvent == null)
            currentEvent = new UnityEvent<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out InteractAction action))
        {
            if (action.CheckInteractable())
            {
                RemoveInteractAction();
                SetInteractAction(action);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out InteractAction action))
        {
            RemoveInteractAction();
            guide.OffGuide();
        }
    }
    private void SetInteractAction(InteractAction _action)
    {
        currentAction = _action;
        currentEvent.AddListener(_action.Action);
        guide.OnGuide(_action.GetGuidePosition());
    }
    private void RemoveInteractAction()
    {
        currentEvent.RemoveAllListeners();
    }

    public void OnInteract()
    {
        currentEvent?.Invoke(gameObject);
        if (currentAction != null && !currentAction.CheckInteractable())
        {
            RemoveInteractAction();
            guide.OffGuide();
        }
    }
}

using UnityEngine.Events;

interface Interact
{
    UnityAction GetInteractAction();
    bool IsInteractable { get; }
}
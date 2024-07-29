using UnityEngine.Events;

interface Interact
{
    UnityAction GetInteractAction();
    void CancelInteract();
}
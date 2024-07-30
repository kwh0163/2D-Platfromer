using UnityEngine;
using UnityEngine.Events;

interface Interact
{
    UnityAction<GameObject> GetInteractAction();
    bool IsInteractable { get; }
}
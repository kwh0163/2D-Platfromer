using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedAction : InteractAction
{
    [SerializeField] private Dialogue successDialogue;
    [SerializeField] private Dialogue faildedDialogue;
    [SerializeField] private Item neededItem;
    [SerializeField] private Transform outTransform;
    [SerializeField] private Vector3 outPositionOffset;

    private bool isLocked;
    public override void Action(GameObject _gameObject)
    {
        if (isLocked)
        {
            if (PlayerInvectory.Instance.CheckItemContains(neededItem.ID))
            {
                isLocked = false;
                PrintText(_gameObject, successDialogue);
            }
            else
                PrintText(_gameObject, faildedDialogue);
        }
        else
        {
            TeleportObject(_gameObject);
        }
    }

    protected override void Start()
    {
        base.Start();
        isLocked = true;
    }
    private void PrintText(GameObject _gameObject, Dialogue _dialogue)
    {
        _gameObject.GetComponent<PlayerInteract>()
            .textBox.StartPrintText(_dialogue.stringList);
    }
    private void TeleportObject(GameObject _object)
    {
        _object.transform.root.position = 
            outTransform.position + outPositionOffset;
    }
}

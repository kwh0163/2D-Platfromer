using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAction : InteractAction
{
    [SerializeField] protected List<Dialogue> dialogueList;
    [SerializeField] private int itemGiveIndex;
    [SerializeField] private bool isDisposable;
    protected int currentIndex;
    public override void Action(GameObject _gameObject)
    {
        if (currentIndex == itemGiveIndex)
            GiveItem(_gameObject);
        _gameObject.GetComponent<PlayerInteract>().textBox.StartPrintText(GetCurrentText());
        isInteractable = currentIndex < dialogueList.Count;
    }

    protected override void Start()
    {
        base.Start();
        currentIndex = 0;
    }
    private List<string> GetCurrentText()
    {
        int returnIndex = currentIndex;
        if (isDisposable)
            currentIndex++;
        return dialogueList[returnIndex].stringList;
    }
}

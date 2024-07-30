using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAction : InteractAction
{
    [SerializeField] private List<Dialogue> dialogueList;
    private int currentIndex;
    public override void Action(GameObject _gameObject)
    {
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
        return dialogueList[currentIndex++].stringList;
    }
}

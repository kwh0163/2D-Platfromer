using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAction : InteractAction
{
    [SerializeField] private List<string> textList;
    private int currentIndex;
    public override void Action()
    {
        Debug.Log(GetCurrentText());
        isInteractable = currentIndex < textList.Count;
    }

    protected override void Start()
    {
        base.Start();
        currentIndex = 0;
    }
    private string GetCurrentText()
    {
        return textList[currentIndex++];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTextBox : MonoBehaviour
{
    [SerializeField] private TextBox text;

    private PlayerAction action;
    private List<string> stringList;

    public bool IsPrinting { get; private set; }

    private void Awake()
    {
        action = GetComponentInParent<PlayerAction>();
    }
    private void Start()
    {
        IsPrinting = false;
    }
    public void StartPrintText(List<string> _stringList)
    {
        action.ChangeUI();
        IsPrinting = true;
        SetCurrentTextBox();
        stringList = _stringList;
        StartCoroutine(PrintText());
    }
    IEnumerator PrintText()
    {
        text.ShowText(stringList);
        yield return new WaitUntil(() => text.IsDialogueEnd);
        IsPrinting = false;
        text.ActiveOffTextBox();
        action.ChangeWalk();
    }
    private void SetCurrentTextBox()
    {
        bool isUp = Camera.main.WorldToViewportPoint
            (transform.position).y > 0.5f;
        if (isUp)
        {
            text.SetUpText();
            text.ActiveUpTextBox();
        }
        else
        {
            text.SetDownText();
            text.ActiveDownTextBox();
        }
    }

    public void OnSkipText()
    {
        if (text.IsStringEnd)
            text.NextDialogue();
        else
            text.SkipString();
    }
}

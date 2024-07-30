using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    [SerializeField] private GameObject upTextBox;
    [SerializeField] private GameObject downTextBox;
    [SerializeField] private float textInterval;

    private Text upText;
    private Text downText;

    private Text currentText;
    private string endString;
    Coroutine currentCoroutine;

    private bool nextString;

    public bool IsStringEnd { get; private set; }
    public bool IsDialogueEnd { get; private set; }
    

    private void Awake()
    {
        upText = upTextBox.GetComponentInChildren<Text>();
        downText = downTextBox.GetComponentInChildren<Text>();
    }

    private void Start()
    {
        ActiveOffTextBox();
        IsDialogueEnd = true;
    }

    public void ShowText(List<string> _textString)
    {
        IsDialogueEnd = false;
        StartCoroutine(PrintDialogue(_textString));
    }
    IEnumerator PrintDialogue(List<string> _textString)
    {
        for (int i = 0; i < _textString.Count; i++)
        {
            nextString = false;
            IsStringEnd = false;
            endString = _textString[i];
            currentCoroutine = StartCoroutine(PrintString());
            yield return new WaitUntil(() => IsStringEnd);
            yield return new WaitUntil(() => nextString);
            ClearText();
        }
        IsDialogueEnd = true;
        yield return null;
    }
    IEnumerator PrintString()
    {
        for (int i = 0; i < endString.Length; i++)
        {
            string printString = endString.Substring(0, i + 1);
            currentText.text = printString;
            
            yield return new WaitForSeconds(textInterval);
        }
        IsStringEnd = true;
        yield return null;
    }
    public void NextDialogue()
    {
        if(IsStringEnd)
            nextString = true;
    }
    public void SkipString()
    {
        IsStringEnd = true;
        StopCoroutine(currentCoroutine);
        currentText.text = endString;
    }
    public void ClearText()
    {
        currentText.text = "";
    }
    public void ActiveUpTextBox()
    {
        upTextBox.SetActive(true);
    }
    public void ActiveDownTextBox()
    {
        downTextBox.SetActive(true);
    }
    public void ActiveOffTextBox()
    {
        upTextBox.SetActive(false);
        downTextBox.SetActive(false);
    }
    public void SetUpText()
    {
        currentText = upText;
    }
    public void SetDownText()
    {
        currentText = downText;
    }
}

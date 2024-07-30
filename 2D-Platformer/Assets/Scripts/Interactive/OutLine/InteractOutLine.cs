using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOutLine : MonoBehaviour
{
    private Material material;
    private InteractAction action;
    private bool isLineOn;
    private bool isPlayerEnter;
    private void Start()
    {
        isLineOn = false;
        isPlayerEnter = false;
    }
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        action = GetComponent<InteractAction>();
    }

    private void FixedUpdate()
    {
        if (isPlayerEnter)
        {
            if (action.CheckInteractable())
                OnOutLine();
            else
                OffOutLine();
        }
        else
            OffOutLine();
    }

    public void OnOutLine()
    {
        if (isLineOn)
            return;
        isLineOn = true;
        material.SetFloat("_OutlineEnabled", 1);
    }
    public void OffOutLine()
    {
        if (!isLineOn)
            return;
        isLineOn = false;
        material.SetFloat("_OutlineEnabled", 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayerEnter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayerEnter = false;
    }
}

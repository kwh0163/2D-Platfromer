using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOutLine : MonoBehaviour
{
    private Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    public void OnOutLine()
    {
        Debug.Log("Called On");
        material.SetFloat("_OutlineEnabled", 1);
    }
    public void OffOutLine()
    {
        Debug.Log("Called Off");
        material.SetFloat("_OutlineEnabled", 0);
    }
}

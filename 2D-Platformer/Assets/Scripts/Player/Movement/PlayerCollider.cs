using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private CapsuleCollider2D defaultCollider;
    private BoxCollider2D slideCollider;

    private void Awake()
    {
        defaultCollider = GetComponent<CapsuleCollider2D>();
        slideCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        slideCollider.enabled = false;
    }

    public void OnSlide()
    {
        defaultCollider.enabled = false;
        slideCollider.enabled = true;
    }

    public void OnDefault()
    {
        defaultCollider.enabled = true;
        slideCollider.enabled = false;
    }
}

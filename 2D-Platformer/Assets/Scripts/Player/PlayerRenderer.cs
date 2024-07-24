using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    [SerializeField] private GameObject spriteChild;

    private SpriteRenderer sprite;

    void Start()
    {
        sprite = spriteChild.GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool _isFliped)
    {
        sprite.flipX = _isFliped;
    }

}

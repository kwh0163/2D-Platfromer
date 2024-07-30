using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : InteractAction
{
    SpriteRenderer sprite;

    private bool isOn;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        isOn = false;
    }

    public override void Action(GameObject _gameObject)
    {
        if (isOn)
            sprite.color = Color.blue;
        else
            sprite.color = Color.red;
        isOn = !isOn;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : InteractAction
{
    [SerializeField] private Transform outTransform;
    [SerializeField] private Vector3 outPositionOffset;
    public override void Action(GameObject _gameObject)
    {
        TeleportObject(_gameObject);
    }

    private void TeleportObject(GameObject _object)
    {
        _object.transform.root.position = 
            outTransform.position+ outPositionOffset;
    }
}

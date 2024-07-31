using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : InteractAction
{
    [SerializeField] private Portal outPortal;
    [SerializeField] private Vector3 outPositionOffset;
    public override void Action(GameObject _gameObject)
    {
        TeleportObject(_gameObject.transform.root.gameObject);
    }

    private void TeleportObject(GameObject _object)
    {
        _object.transform.position = outPortal.transform.position
            + outPositionOffset;
    }
}

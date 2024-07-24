using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGround : MonoBehaviour
{
    [SerializeField] private Vector3 rayCastOffset;
    [SerializeField] private float groundLength;
    [SerializeField] private LayerMask groundLayer;

    public bool OnGround { get; private set; }


    void Update()
    {
        OnGround = CheckIsGrounded();
    }

    private void OnDrawGizmos()
    {
        if (OnGround)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + rayCastOffset,
            transform.position + rayCastOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - rayCastOffset,
            transform.position - rayCastOffset + Vector3.down * groundLength);
    }

    private bool CheckIsGrounded()
    {
        return
            Physics2D.Raycast(transform.position + rayCastOffset,
            Vector2.down, groundLength, groundLayer) ||
            Physics2D.Raycast(transform.position - rayCastOffset,
            Vector2.down, groundLength, groundLayer);
    }
}

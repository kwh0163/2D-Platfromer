using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private float timeToJumpApex;

    private bool desiredJump;
    private bool isJumpPressed;
    private float gravityMultiplier;

    private Rigidbody2D rigid;
    private PlayerGround ground;
    private Vector2 direction;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ground = GetComponent<PlayerGround>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetGravity()
    {
        float newGravity = (-2 * jumpHeight) / (timeToJumpApex * timeToJumpApex);
        rigid.gravityScale = (newGravity / Physics2D.gravity.y) * gravityMultiplier;
    }

    public void StartJump()
    {
        desiredJump = true;
        isJumpPressed = true;
    }
    public void CancelJump()
    {
        isJumpPressed = false;
    }
}

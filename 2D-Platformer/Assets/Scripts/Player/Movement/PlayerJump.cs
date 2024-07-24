using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private float upwardMultiplier;
    [SerializeField] private float downwardMultiplier;
    [SerializeField] private float speedLimit;
    [SerializeField] private float timeToJumpApex;
    [SerializeField] private float coyoteTime;
    [SerializeField] private float jumpBuffer;

    private bool onGround;
    private bool desiredJump;
    private bool isJumping;
    private float gravityMultiplier;
    private float defaultGravityScale;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    private Rigidbody2D rigid;
    private PlayerGround ground;
    private Vector2 velocity;

    void Start()
    {
        defaultGravityScale = 1f;
        jumpBufferCounter = 0;
        coyoteTimeCounter = 0;
        rigid = GetComponent<Rigidbody2D>();
        ground = GetComponent<PlayerGround>();
    }

    void Update()
    {
        SetGravity();

        onGround = ground.OnGround;

        CheckJumpBuffer();

        if (!isJumping && !onGround)
            coyoteTimeCounter += Time.deltaTime;
        else
            coyoteTimeCounter = 0;
    }

    private void FixedUpdate()
    {
        velocity = rigid.velocity;

        if (desiredJump)
        {
            DoJump();
            rigid.velocity = velocity;

            return;
        }
        CalculateGravity();
    }

    private void DoJump()
    {
        if(onGround || (coyoteTimeCounter > 0.03f &&coyoteTimeCounter < coyoteTime))
        {
            desiredJump = false;
            jumpBufferCounter = 0;
            coyoteTimeCounter = 0;

            //더블 점프 나중에 추가

            velocity.y += GetJumpSpeed();
            isJumping = true;
        }
        if(jumpBuffer == 0)
        {
            desiredJump = false;
        }
    }
    private void CheckJumpBuffer()
    {
        if (jumpBuffer > 0)
        {
            if (desiredJump)
            {
                jumpBufferCounter += Time.deltaTime;
                if (jumpBufferCounter > jumpBuffer)
                {
                    desiredJump = false;
                    jumpBufferCounter = 0;
                }
            }
        }
    }
    private float GetJumpSpeed()
    {
        float jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * rigid.gravityScale * jumpHeight);

        if (velocity.y > 0f)
            jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
        else if (velocity.y < 0f)
            jumpSpeed += Mathf.Abs(rigid.velocity.y);
        return jumpSpeed;
    }

    private void CalculateGravity()
    {
        if(rigid.velocity.y > 0.01f)
        {
            if (onGround)
                gravityMultiplier = defaultGravityScale;
            else
                gravityMultiplier = upwardMultiplier;
        }
        else if(rigid.velocity.y < -0.01f)
        {
            if (onGround)
                gravityMultiplier = defaultGravityScale;
            else
                gravityMultiplier = downwardMultiplier;
        }
        else
        {
            if (onGround)
                isJumping = false;

            gravityMultiplier = defaultGravityScale;
        }

        rigid.velocity = new Vector3(velocity.x, Mathf.Clamp(velocity.y, -speedLimit, 100));
    }

    private void SetGravity()
    {
        float newGravity = (-2 * jumpHeight) / (timeToJumpApex * timeToJumpApex);
        rigid.gravityScale = (newGravity / Physics2D.gravity.y) * gravityMultiplier;
    }

    public void StartJump()
    {
        desiredJump = true;
    }
}

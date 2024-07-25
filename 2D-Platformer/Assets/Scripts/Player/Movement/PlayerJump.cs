using System;
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

    public bool IsJumping { get; private set; }
    public float ApexTime { get { return timeToJumpApex; } }

    private Vector2 velocity;
    private bool onGround;
    private bool desiredJump;
    private float gravityMultiplier;
    private float defaultGravityScale;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;
    private float jumpApexCounter;

    private Rigidbody2D rigid;
    private PlayerGround ground;

    public Action JumpAction;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        ground = GetComponent<PlayerGround>();
    }

    private void Start()
    {
        defaultGravityScale = 1f;
        jumpBufferCounter = 0;
        coyoteTimeCounter = 0;
    }

    void Update()
    {
        SetGravity();

        onGround = ground.OnGround;

        CheckJumpBuffer();

        if (!IsJumping && !onGround)
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
            IsJumping = true;
        }
        if(jumpBuffer == 0)
        {
            desiredJump = false;
        }
        JumpAction?.Invoke();
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
                IsJumping = false;

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
    public float GetVeloctyY()
    {
        return velocity.y;
    }
}

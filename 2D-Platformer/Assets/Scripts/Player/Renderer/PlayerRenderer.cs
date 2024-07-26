using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    private PlayerGround ground;
    private PlayerMovement movement;
    private PlayerJump jump;
    private PlayerSlide slide;

    private PlayerSprite sprite;
    private PlayerAnimator animator;

    private bool playerGrounded;
    private bool isJumped;
    private bool isFalling;
    private float apexTimeCounter;

    private void Awake()
    {
        ground = GetComponentInParent<PlayerGround>();
        movement = GetComponentInParent<PlayerMovement>();
        jump = GetComponentInParent<PlayerJump>();
        slide = GetComponentInParent<PlayerSlide>();

        sprite = GetComponent<PlayerSprite>();
        animator = GetComponent<PlayerAnimator>();
    }
    private void Start()
    {
        jump.JumpAction += JumpEffect;
        apexTimeCounter = 0;
        isFalling = false;
        isJumped = false;
    }

    private void Update()
    {
        RunEffect();
        CheckSliding();
        CheckFalling();
        CheckLanding();
    }

    private void RunEffect()
    {
        if (slide.IsSliding)
            return;
        float directionX = movement.GetDirection().x;
        animator.SetIsRunning(directionX != 0);
        if (directionX != 0)
        {
            sprite.FlipSprite(directionX < 0);
        }
    }
    private void CheckFalling()
    {
        if (playerGrounded)
        {
            animator.TriggerLanded();
            return;
        }
        isFalling = jump.GetVeloctyY() < 0;
        if (isFalling)
        {
            animator.TriggerFall();
            isJumped = false;
            return;
        }
        if (isJumped)
        {
            apexTimeCounter += Time.deltaTime;
            if(apexTimeCounter >= jump.ApexTime)
            {
                animator.JumpToFall();
                apexTimeCounter = 0;
                isJumped = false;
            }
            return;
        }
    }
    private void CheckLanding()
    {
        if(!playerGrounded && ground.OnGround)
        {
            playerGrounded = true;
            isFalling = false;

            animator.TriggerLanded();
        }
        else if(playerGrounded && !ground.OnGround)
        {
            playerGrounded = false;
        }
    }
    private void CheckSliding()
    {
        animator.SetIsSliding(slide.IsSliding);
    }
    private void JumpEffect()
    {
        animator.TriggerJump();
        isJumped = true;
    }
}

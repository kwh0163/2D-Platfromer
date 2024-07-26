using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSlide : MonoBehaviour
{
    [SerializeField] private float conditionSpeedToSlide;
    [SerializeField] private float slideTime;
    [SerializeField] private float slideTimeOffset;
    [SerializeField] private float slideSpeedMultiplier = 1;

    public bool IsSliding { get; private set; }

    private float slideTimeCounter;
    private float gradient;
    private float currentSlideSpeed;
    private float maxVelocityX;


    private PlayerJump jump;
    private PlayerGround ground;
    private PlayerCollider playerCollider;

    private Rigidbody2D rigid;

    private void Awake()
    {
        jump = GetComponent<PlayerJump>();
        ground = GetComponent<PlayerGround>();
        playerCollider = GetComponent<PlayerCollider>();

        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        IsSliding = false;
        jump.JumpAction += CancelSlide;
        slideTimeCounter = 0;
    }

    private void Update()
    {
        CheckSlide();
    }
    private void CheckSlide()
    {
        if(IsSliding)
        {
            slideTimeCounter += Time.deltaTime;

            SetCurrentSpeed(slideTimeCounter);

            if (slideTimeCounter >= slideTime)
            {
                CancelSlide();
            }
        }
    }
    private void SetCurrentSpeed(float _t)
    {
        currentSlideSpeed = gradient * _t + maxVelocityX;
    }
    public void ActiveSlide()
    {
        if (ground.OnGround)
        {
            maxVelocityX = rigid.velocity.x * slideSpeedMultiplier;

            if (Mathf.Abs(maxVelocityX) < conditionSpeedToSlide)
                return;

            gradient = -(maxVelocityX / (slideTime + slideTimeOffset));
            playerCollider.OnSlide();
            IsSliding = true;
            Debug.Log(rigid.velocity.x);
        }
    }
    public void CancelSlide()
    {
        playerCollider.OnDefault();
        slideTimeCounter = 0;
        IsSliding = false;
    }

    public float GetSlideVelocityX()
    {
        return currentSlideSpeed;
    }
}

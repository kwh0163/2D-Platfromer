using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float friction;

    [SerializeField] private float maxAirAccel;
    [SerializeField] private float maxAirDecel;
    [SerializeField] private float maxAirTunSpeed;

    private Vector2 direction;
    private Vector2 velocity;
    private Vector2 desiredVelocity;

    private Rigidbody2D rigid;
    private PlayerGround ground;
    private PlayerRenderer renderer;

    private bool isKeyPressed;

    private void Start()
    {
        direction = Vector2.zero;
        rigid = GetComponent<Rigidbody2D>();
        ground = GetComponent<PlayerGround>();
        renderer = GetComponent<PlayerRenderer>();
    }

    private void Update()
    {
        if(direction.x != 0)
        {
            isKeyPressed = true;
            renderer.FlipSprite(direction.x < 0);
        }
        else
        {
            isKeyPressed = false;
        }

        desiredVelocity = direction * Mathf.Max(maxSpeed - friction, 0f);
    }

    private void FixedUpdate()
    {
        velocity = rigid.velocity;

        if (ground.OnGround)
            RunWithoutAccel();
        else
            RunWithAccel();
    }

    private void RunWithAccel()
    {
        float maxSpeedChange;
        if (isKeyPressed)
        {
            if (Mathf.Sign(direction.x) != Mathf.Sign(velocity.x))
                maxSpeedChange = maxAirTunSpeed * Time.deltaTime;
            else
                maxSpeedChange = maxAirAccel * Time.deltaTime;
        }
        else
            maxSpeedChange = maxAirDecel * Time.deltaTime;
        
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        rigid.velocity = velocity;
    }

    private void RunWithoutAccel()
    {
        velocity.x = desiredVelocity.x;

        rigid.velocity = velocity;
    }

    public void SetDirection(float _directionX)
    {
        direction.x = _directionX;
    }
}

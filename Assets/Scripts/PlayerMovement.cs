using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private float speed = 10f; 
    private Rigidbody2D rb;
    private Vector2 direction = new Vector2(1,0);
    private BoxCollider2D coll;
    [SerializeField]private float jumpPower;
    private bool isJumping = false;
    private SpriteRenderer sprite;
    private enum MovementState
    {
        idle,
        running,
        jump,
        falling
    }

    private MovementState _state = MovementState.idle;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MovementCheck();
        Jump();
    }

    void FixedUpdate()
    {
        Move();
        
    }

    public void Move()
    {
        
        
        direction.x = Input.GetAxisRaw("Horizontal") * speed ;
        direction.y = rb.velocity.y;
        rb.velocity = direction;
        
        
    }

    public void Jump()
    {
        
        if ((Input.GetKeyDown("w") || Input.GetKeyDown("space")))
        {
            
            rb.AddForce(Vector2.up * jumpPower);
            isJumping = true;
        }
        
    }

    private void MovementCheck()
    {
        if (direction.x > 0)
        {
            _state = MovementState.running;
            sprite.flipX = false;
        }
        else if(direction.x < 0)
        {
            _state = MovementState.running;
            sprite.flipX = true;
           
        }
        else
        {
            _state = MovementState.idle;
            
        }
       
        if (rb.velocity.y > 0.1f)
        {
            _state = MovementState.jump;
        }
        if (rb.velocity.y < -0.1f)
        {
            _state = MovementState.falling;
        }

        anim.SetInteger("state", (int)_state);
    }
    public void CheckGround()
    {
        throw new NotImplementedException();
    }
}

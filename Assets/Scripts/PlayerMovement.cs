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
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        
        Jump();
        direction.x = Input.GetAxisRaw("Horizontal") * speed ;
        direction.y = rb.velocity.y;
        rb.velocity = direction;
        
        
    }

    public void Jump()
    {
        if ((Input.GetKey("w") || Input.GetKey("space")) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpPower);
            Debug.Log("added force");
            isJumping = true;
            Debug.Log("airborned");
        }
    }

    private void MovementCheck()
    {
        if (direction.x > 0)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if(direction.x < 0)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
    public void CheckGround()
    {
        throw new NotImplementedException();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private float speed = 10f; 
    private Rigidbody2D rb;
    private Vector2 direction = new Vector2(1,0);
    private BoxCollider2D coll;
    [SerializeField]private float jumpPower;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private GameObject AttackPoint;
    private AudioSource Au;
    [SerializeField] private float dashPower;
    private float nextDashTime = 0f;
    [SerializeField] private float dashCD;
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
        coll = GetComponent<BoxCollider2D>();
        Au = GetComponent<AudioSource>();
    }

    private void Update()
    {
        MovementCheck();
        Jump();
        Dash();
    }

    void FixedUpdate()
    {
        Move();
        
    }

    public void Move()
    {
        
        
        direction.x = Input.GetAxis("Horizontal") * speed ;
        direction.y = rb.velocity.y;
        rb.velocity = direction;
        
        
    }

    public void Jump()
    {
        
        if ((Input.GetKeyDown("w") || Input.GetKeyDown("space")) && CheckGround())
        {
            
            rb.AddForce(Vector2.up * jumpPower);
        }
        
    }

    private void MovementCheck()
    {
        if (direction.x > 0)
        {
            _state = MovementState.running;
            sprite.flipX = false;
            AttackPoint.transform.localPosition = new Vector3(0.764f, 0.853f, 0f);
        }
        else if(direction.x < 0)
        {
            _state = MovementState.running;
            sprite.flipX = true;
            AttackPoint.transform.localPosition = new Vector3(-0.764f, 0.853f,0f);

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
    public bool CheckGround()
    {

        return Physics2D.BoxCast(coll.bounds.center,
            coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void Dash()
    {
        if (Input.GetKeyDown("j") && (nextDashTime <= Time.time)) 
        {
            if (direction.x > 0)
            {
                rb.AddForce(Vector2.right * dashPower);
                Au.Play();
            }

            if (direction.x < 0)
            {
                rb.AddForce(Vector2.left * dashPower);
                Au.Play();
            }

            nextDashTime = Time.time + dashCD;
        }
    }
}

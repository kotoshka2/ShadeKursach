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
        
        if ((Input.GetKeyDown("w") || Input.GetKeyDown("space")) && CheckGround())
        {
            
            rb.AddForce(Vector2.up * jumpPower);
<<<<<<< HEAD

=======
            
>>>>>>> dfaeb1ad33507a5de2c90ae1d33cc4646045d3b9
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
}

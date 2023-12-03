using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private float speed = 10f; 
    private Rigidbody2D rb;
    private Vector2 direction = new Vector2(1,0);
    [SerializeField]private bool _isAirborne = false;
    [SerializeField]private float jumpPower;
    private bool isJumping = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        
        Jump();
        direction.x = Input.GetAxis("Horizontal") * speed ;
        direction.y = rb.velocity.y;
        rb.velocity = direction;
    }

    public void Jump()
    {
        if ((Input.GetKey("w") || Input.GetKey("space")) && !_isAirborne)
        {
            rb.AddForce(Vector2.up * jumpPower);
            Debug.Log("added force");
            _isAirborne = true;
            Debug.Log("airborned");
        }
    }

    public void CheckGround()
    {
        
    }
}

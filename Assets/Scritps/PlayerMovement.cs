using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7.5f;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private float horizontal;
    private float vertical;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }
    
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        transform.position = new Vector2(transform.position.x + (horizontal * speed * Time.deltaTime),
            transform.position.y + (vertical * speed * Time.deltaTime));
        
        rb.velocity = Vector2.right * (horizontal * speed);
        
    }
    
}

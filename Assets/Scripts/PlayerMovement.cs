using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    
   [Range(0, 10)]
   public float speed = 6f;
    private Vector3 pos;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private float horizontal;
    private float vertical;
    [Range(0, 1)]
    public float step = 0.25f;

    private void Awake()
    {
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }
    
    private void Update()
    {
        // horizontal = Input.GetAxis("Horizontal");
        // vertical = Input.GetAxis("Vertical");
        //
        // transform.position = new Vector2(transform.position.x + (horizontal * speed * Time.deltaTime),
        //     transform.position.y + (vertical * speed * Time.deltaTime));
        //
        // rb.velocity = Vector2.right * (horizontal * speed);
        
        PokemonMovement();
    }

    private void PokemonMovement()
    {
        if (Input.GetKey("w") && transform.position == pos)
        {
                pos += Vector3.up * step;
        }
            
        if (Input.GetKey("a") && transform.position == pos)
        {
                pos += Vector3.left * step;
        }
        
        if (Input.GetKey("s") && transform.position == pos)
        {
            pos += Vector3.down * step;
        }
        
        if (Input.GetKey("d") && transform.position == pos)
        {
            pos += Vector3.right * step;
        }
    
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
    }
}

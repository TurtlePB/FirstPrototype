using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7.5f;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private float horizontal;
    private float vertical;
    public Transform parent;
    private bool hasItem;
    private int f;
    [SerializeField] private LayerMask foodLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        hasItem = false;
    }
    
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        transform.position = new Vector2(transform.position.x + (horizontal * speed * Time.deltaTime),
            transform.position.y + (vertical * speed * Time.deltaTime));
        
        rb.velocity = Vector2.right * (horizontal * speed);
        
        // AdoptionAndAbandonment();
    }

    #region FoodTransportation
    
    private void PickingFoodUp()
    {
        Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 0.5f, foodLayer);
        
        foreach (var f  in food)
        {
            f.gameObject.transform.SetParent(parent);
            return;
        }
    }
    
    public void AdoptionAndAbandonment()
    {
        if (Input.GetKeyDown("e"))
        {
            if (hasItem == false)
            {
                PickingFoodUp();
                hasItem = true;
            }
            else
            {
                DropFood();
                hasItem = false;
            }
        }
    }

    public void DropFood()
    {
        Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1f, foodLayer);

        foreach (var f in food)
        {
            f.gameObject.transform.parent = null;
            return;
        }
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, 1f);
    // }
    #endregion
    //Currently in Hands Script!!!
}

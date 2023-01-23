using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Hands : MonoBehaviour
{
    private Spawner _foodSpawner;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public Transform parent;
    private bool hasItem;
    [SerializeField] private LayerMask foodLayer;
    private float timePressed;
    [SerializeField] private float CoolDown = 0.75f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        _foodSpawner = FindObjectOfType<Spawner>();
        hasItem = false;
        timePressed = CoolDown;
    }
    
    void Update()
    {
        AdoptionAndAbandonment();
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
        }

        if (Input.GetKey("e") && hasItem)
        {
            timePressed -= Time.deltaTime;
            
            if (timePressed <= 0)
            {
                DropFood();
                hasItem = false;
                timePressed = CoolDown;
            }
        }

        if (Input.GetKeyUp("e"))
        {
            timePressed = CoolDown;
        }
    }
    
    private void PickingFoodUp()
    {
        Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 0.5f, foodLayer);
        
        foreach (var f  in food)
        {
            f.gameObject.transform.SetParent(parent); 
            f.transform.position = parent.position;
            _foodSpawner.existingBurger = false;
            _foodSpawner.existingSoda = false;
            _foodSpawner.existingPommes = false;
            return;
        }
    }

    public void DropFood()
    {
        Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 0.5f, foodLayer);

        foreach (var f in food)
        {
            f.gameObject.transform.parent = null;
            return;
        }
    }

    #region TablePlacment
    
    // private void CustomerSatisfaction()
    // {
    //     if (Input.GetKey("q"))
    //     {
    //         if (hasItem == true)
    //         {
    //             PlaceOnTable();
    //             hasItem = false;
    //         }
    //     }
    // }
    //
    // private void PlaceOnTable()
    // {
    //     Collider2D[] table = Physics2D.OverlapCircleAll(transform.position, 0.5f, tableLayer);
    //
    //     foreach (var t in table)
    //     {
    //         t.gameObject.transform.SetParent(theTable);
    //         t.transform.position = parent.position;
    //         return;
    //     }
    // }
    
    #endregion
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}

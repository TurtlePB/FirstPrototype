using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public Transform parent;
    private bool hasItem;
    [SerializeField] private LayerMask foodLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        hasItem = false;
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
            else
            {
                DropFood();
                hasItem = false;
            }
        }
    }
    
    private void PickingFoodUp()
    {
        Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 0.2f, foodLayer);
        
        foreach (var f  in food)
        {
            f.gameObject.transform.SetParent(parent);
            return;
        }
    }
    
    public void DropFood()
    {
        Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 0.2f, foodLayer);

        foreach (var f in food)
        {
            f.gameObject.transform.parent = null;
            return;
        }
    }
    
    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, 0.2f);
    // }
}

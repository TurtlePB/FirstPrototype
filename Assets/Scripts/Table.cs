using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public Transform theTable;
    private bool hasItem;
    [SerializeField] private LayerMask foodLayer;
    // Start is called before the first frame update
    void Start()
    {
        hasItem = true;
    }

    // Update is called once per frame
    void Update()
    {
        CustomerSatisfaction();
    }
    
    private void CustomerSatisfaction()
    {
        if (Input.GetKeyDown("e"))
        {
            if (hasItem == true)
            {
                PlaceOnTable();
            }
        }
    }
    
    private void PlaceOnTable()
    {
        Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);

        foreach (var f in food)
        {
            f.gameObject.transform.SetParent(theTable);
            f.transform.position = theTable.position;
            // f.transform.localPosition.z = theTable;
            return;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 1.1f);
    }
}

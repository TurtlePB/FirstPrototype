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
    [SerializeField] private LayerMask tableLayer;
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
        if (Input.GetKey("q"))
        {
            if (hasItem == true)
            {
                PlaceOnTable();
            }
        }
    }
    
    private void PlaceOnTable()
    {
        Collider2D[] table = Physics2D.OverlapCircleAll(transform.position, 1.5f, tableLayer);

        foreach (var t in table)
        {
            t.gameObject.transform.SetParent(theTable);
            t.transform.position = theTable.position;
            return;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}

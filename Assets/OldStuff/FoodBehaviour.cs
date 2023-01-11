using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodBehaviour : MonoBehaviour
{
    private BoxCollider2D bc;
    public GameObject child;
    // private bool hasItem;
    public Transform parent;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        // hasItem = false;
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         AdoptionAndAbandonment(parent);
    //         //TODO: doesn't work yet
    //     }
    // }

    // public void AdoptionAndAbandonment(Transform newParent)
    // {
    //     if (Input.GetKeyDown("e"))
    //     {
    //         if (hasItem == false)
    //         {
    //             child.transform.SetParent(newParent, true);
    //             hasItem = true;
    //         }
    //         else
    //         {
    //             child.transform.parent = null;
    //             hasItem = false;
    //         }
    //     }
    // }

    void Update()
    {
        // AdoptionAndAbandonment(parent);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Table : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    public Transform theTable;
    private bool hasItem;
    public bool itemIsPlaced;
    [SerializeField] private LayerMask foodLayer;
    private NPCMovement _npcMovement;
    private bool isWishing;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        hasItem = true;
        itemIsPlaced = false;
        isWishing = false;
        // npc.checkIfTableIsFree = true;
    }

    // Update is called once per frame
    void Update()
    {
        CustomerSatisfaction();
        FoodWishAttempt1();
    }
    
    private void CustomerSatisfaction()
    {
        if (Input.GetKeyDown("e"))
        {
            if (hasItem == true)
            {
                PlaceOnTable();
                itemIsPlaced = true;
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
            return;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 1.1f);
    }
    
    private void FoodWishAttempt1()
    {
        if (_npcMovement.isSitting == true)
        {
            if (isWishing == false)
            {
                sr.sprite = _npcMovement.listOfFoodWishes[Random.Range(0, _npcMovement.listOfFoodWishes.Count)];
                isWishing = true;
            }

            if (sr.sprite == _npcMovement.listOfFoodWishes[0] && itemIsPlaced == true)
            {
                Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);

                foreach (var burger in food)
                {
                    if (CompareTag("Burger"))
                    {
                        burger.gameObject.SetActive(false);
                        print("yummy");
                    }
                }
            }

            if (sr.sprite == _npcMovement.listOfFoodWishes[1] && itemIsPlaced == true)
            {
                Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);

                foreach (var soda in food)
                {
                    if (CompareTag("Soda"))
                    {
                        soda.gameObject.SetActive(false);
                        print("juicy");
                    }
                } 
            }
        }
    }
}

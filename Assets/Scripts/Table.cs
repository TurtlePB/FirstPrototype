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
    [SerializeField] private List<GameObject> ListOfFoodStuff;
    public NPCMovement _npcMovement;
    public FoodManager _foodManager;
    private bool isWishing;

    private int foodID;

    private GameObject _FoodItem;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        hasItem = true;
        itemIsPlaced = false;
        isWishing = false;
    }

    // Update is called once per frame
    void Update()
    {
        CustomerSatisfaction();
        // FoodWishAttempt1();
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
            itemIsPlaced = true;
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
                _FoodItem = ListOfFoodStuff[Random.Range(0, ListOfFoodStuff.Count)];
                //könnte man ausprobieren
                // foodID = _npcMovement.listOfFoodWishes[Random.Range(0,_npcMovement.listOfFoodWishes.Count)];
                //Fehler ist kein Sprite sondern int
                // _npcMovement.sr.sprite = _npcMovement.listOfFoodWishes[Random.Range(0, _npcMovement.listOfFoodWishes.Count)];
                //Fehler der NPC sprite würde dann geändert werden
                isWishing = true;
            }

            // if (_npcMovement.sr.sprite == _npcMovement.listOfFoodWishes[0] && itemIsPlaced == true)
            // {
            //     Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
            //
            //     foreach (var burger in food)
            //     {
            //         if (CompareTag("Burger"))
            //         {
            //             burger.gameObject.SetActive(false);
            //             print("yummy");
            //         }
            //     }
            // }

            // if (_npcMovement.sr.sprite == _npcMovement.listOfFoodWishes[1] && itemIsPlaced == true)
            // {
            //     Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
            //
            //     foreach (var soda in food)
            //     {
            //         if (CompareTag("Soda"))
            //         {
            //             soda.gameObject.SetActive(false);
            //             print("juicy");
            //         }
            //     } 
            // }
            
            if (_FoodItem == ListOfFoodStuff[0] && itemIsPlaced == true)
            {
                print("i want a burger");
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

            // if (_FoodItem == ListOfFoodStuff[1] && itemIsPlaced == true)
            // {
            //     print("Pommes");
            //     
            //     // Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
            //     //
            //     // foreach (var pommes in food)
            //     // {
            //     //     if (CompareTag("Pommes"))
            //     //     {
            //     //         pommes.gameObject.SetActive(false);
            //     //         print("crunchy");
            //     //     }
            //     // }
            //
            //     if (CompareTag("Pommes"))
            //     {
            //         print("yummy crunchy pommes");
            //     }
            // }

            // if (_FoodItem == ListOfFoodStuff[2] && itemIsPlaced == true)
            // {
            //     print("Soda");
            //     
            //     // Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
            //     //
            //     // foreach (var soda in food)
            //     // {
            //     //     if (CompareTag("Soda"))
            //     //     {
            //     //         soda.gameObject.SetActive(false);
            //     //         print("yummy");
            //     //     }
            //     // }
            //
            //     if (CompareTag("Soda"))
            //     {
            //         print("what a juicy & energising Soda");
            //     }
            // }
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (_npcMovement.isSitting == true)
    //     {
    //         if (isWishing == false)
    //         {
    //             _FoodItem = ListOfFoodStuff[Random.Range(0, ListOfFoodStuff.Count)];
    //             print(_FoodItem);
    //             isWishing = true;
    //         }
    //
    //         if (_FoodItem == ListOfFoodStuff[0] && itemIsPlaced == true)
    //         {
    //             if (other.gameObject.CompareTag("Burger"))
    //             {
    //                 print("what a tasty Burger");
    //             }
    //         }
    //     }
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (_npcMovement.isSitting == true)
    //     {
    //         if (isWishing == false)
    //         {
    //             _FoodItem = ListOfFoodStuff[Random.Range(0, ListOfFoodStuff.Count)];
    //             print(_FoodItem);
    //             isWishing = true;
    //         }
    //
    //         if (_FoodItem == ListOfFoodStuff[0] && itemIsPlaced == true)
    //         {
    //             if (other.gameObject.CompareTag("Burger"))
    //             {
    //                 print("what a tasty Burger");
    //                 other.gameObject.SetActive(false);
    //             }
    //         }
    //     }
    // }
}

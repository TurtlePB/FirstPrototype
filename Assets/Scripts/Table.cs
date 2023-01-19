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
    private bool isWishing;
    private GameObject _FoodItem;
    // public GameObject FoodWishBurger;
    
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
        FoodWishAttempt1();
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
                isWishing = true;
            }

            if (_FoodItem == ListOfFoodStuff[0] && _npcMovement.isSitting)
            {
                _npcMovement.sr.sprite = _npcMovement.listOfFoodWishes[0];
            }
            
            if (_FoodItem == ListOfFoodStuff[0] && itemIsPlaced == true)
            {
                // GameObject newBurgerWish = Instantiate(FoodWishBurger, transform.position, Quaternion.identity);
                Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                
                foreach (var burger in food)
                {
                    if (burger.gameObject.CompareTag("Burger"))
                    {
                        // newBurgerWish.gameObject.SetActive(false);
                        burger.gameObject.SetActive(false);
                        print("yummy");
                    }
                }
                
            }
            
            if (_FoodItem == ListOfFoodStuff[1] && _npcMovement.isSitting)
            {
                _npcMovement.sr.sprite = _npcMovement.listOfFoodWishes[1];
            }
            
            if (_FoodItem == ListOfFoodStuff[1] && itemIsPlaced == true)
            {
                Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                
                foreach (var soda in food)
                {
                    if (soda.gameObject.CompareTag("Soda"))
                    {
                        soda.gameObject.SetActive(false);
                        print("juicy");
                    }
                }
            }
        }
    }
}

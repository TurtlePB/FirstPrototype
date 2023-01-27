using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Table : MonoBehaviour
{
    private Hands _hands;
    
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
    private float eating;
    [SerializeField] private float eatingTime = 1f;
   
    public GameObject FoodWishBurger;
    public GameObject FoodWishSoda;
    public GameObject FoodWishPommes;
    public GameObject FoodWishChicken;
    public GameObject FoodWishDrink;
    public GameObject FoodWishBeer;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        hasItem = true;
        itemIsPlaced = false;
        isWishing = false;
        eating = eatingTime;
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
        // Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.75f,3f), foodLayer);
        Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);

        foreach (var f in food)
        {
            f.gameObject.transform.SetParent(theTable);
            f.transform.position = theTable.position;
            // _hands.maxItems--;
            itemIsPlaced = true;
            return;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        // Gizmos.DrawWireCube(transform.position, new Vector3(1.75f,3f));
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

            // if (_FoodItem == ListOfFoodStuff[0] && _npcMovement.isSitting)
            // {
            //     _npcMovement.sr.sprite = _npcMovement.listOfFoodWishes[0];
            // }
            
            if (_FoodItem == ListOfFoodStuff[0] && itemIsPlaced == true)
            {
                GameObject newBurgerWish = Instantiate(FoodWishBurger, transform.position, Quaternion.identity);
                // Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.75f,3f), foodLayer);
                Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                
                foreach (var burger in food)
                {
                    if (burger.gameObject.CompareTag("Burger"))
                    {
                        newBurgerWish.gameObject.SetActive(false);
                        eating -= Time.deltaTime;
                        // _hands.maxItems--;
                        if (eating < 0)
                        {
                            burger.gameObject.SetActive(false);
                            print("yummy");
                            
                            _npcMovement.foodFinished = true;
                            _npcMovement.isStillInBuilding = true;
                        }
                    }

                    // eating = eatingTime;
                }
                
            }
            
            // if (_FoodItem == ListOfFoodStuff[1] && _npcMovement.isSitting)
            // {
            //     _npcMovement.sr.sprite = _npcMovement.listOfFoodWishes[1];
            // }
            
            if (_FoodItem == ListOfFoodStuff[1] && itemIsPlaced == true)
            {
                GameObject newSodaWish = Instantiate(FoodWishSoda, transform.position, quaternion.identity);
                // Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.75f,3f), foodLayer);
                Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                
                foreach (var soda in food)
                {
                    if (soda.gameObject.CompareTag("Soda"))
                    {
                        newSodaWish.gameObject.SetActive(false);
                        eating -= Time.deltaTime;
                        // _hands.maxItems--;
                        if (eating < 0)
                        {
                            soda.gameObject.SetActive(false);
                            print("juicy");
                            
                            _npcMovement.foodFinished = true;
                            _npcMovement.isStillInBuilding = true;
                        }
                    }

                    // eating = eatingTime;
                }
            }
            
            if (_FoodItem == ListOfFoodStuff[2] && itemIsPlaced == true)
            {
                GameObject newPommesWish = Instantiate(FoodWishPommes, transform.position, quaternion.identity);
                // Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.75f,3f), foodLayer);
                Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                
                foreach (var pommes in food)
                {
                    if (pommes.gameObject.CompareTag("Pommes"))
                    {
                        newPommesWish.gameObject.SetActive(false);
                        eating -= Time.deltaTime;
                        // _hands.maxItems--;
                        if (eating < 0)
                        {
                            pommes.gameObject.SetActive(false);
                            print("Tasty");
                            
                            _npcMovement.foodFinished = true;
                            _npcMovement.isStillInBuilding = true;
                        }
                    }

                    // eating = eatingTime;
                }
            }
            
            if (_FoodItem == ListOfFoodStuff[3] && itemIsPlaced == true)
            {
                GameObject newChickenWish = Instantiate(FoodWishChicken, transform.position, quaternion.identity);
                // Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.75f,3f), foodLayer);
                Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                
                foreach (var chicken in food)
                {
                    if (chicken.gameObject.CompareTag("Chicken"))
                    {
                        newChickenWish.gameObject.SetActive(false);
                        eating -= Time.deltaTime;
                        // _hands.maxItems--;
                        if (eating < 0)
                        {
                            chicken.gameObject.SetActive(false);
                            print("Crispy");
                            
                            _npcMovement.foodFinished = true;
                            _npcMovement.isStillInBuilding = true;
                        }
                    }

                    // eating = eatingTime;
                }
            } 
            
            if (_FoodItem == ListOfFoodStuff[4] && itemIsPlaced == true)
            {
                GameObject newDrinkWish = Instantiate(FoodWishDrink, transform.position, quaternion.identity);
                // Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.75f,3f), foodLayer);
                Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                
                foreach (var Drink in food)
                {
                    if (Drink.gameObject.CompareTag("Drink"))
                    {
                        newDrinkWish.gameObject.SetActive(false);
                        eating -= Time.deltaTime;
                        // _hands.maxItems--;
                        if (eating < 0)
                        {
                            Drink.gameObject.SetActive(false);
                            print("Delicious");
                            
                            _npcMovement.foodFinished = true;
                            _npcMovement.isStillInBuilding = true;
                        }
                    }

                    // eating = eatingTime;
                }
            }
            
            if (_FoodItem == ListOfFoodStuff[5] && itemIsPlaced == true)
            {
                GameObject newBeerWish = Instantiate(FoodWishBeer, transform.position, quaternion.identity);
                // Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.75f,3f), foodLayer);
                Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                
                foreach (var beer in food)
                {
                    if (beer.gameObject.CompareTag("Beer"))
                    {
                        newBeerWish.gameObject.SetActive(false);
                        eating -= Time.deltaTime;
                        // _hands.maxItems--;
                        if (eating < 0)
                        {
                            beer.gameObject.SetActive(false);
                            print("strong Beer");
                            
                            _npcMovement.foodFinished = true;
                            _npcMovement.isStillInBuilding = true;
                        }
                    }

                    // eating = eatingTime;
                }
            }
        }
    }
}

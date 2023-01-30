using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class Table : MonoBehaviour
{
    private Hands _hands;
    public TMP_Text countTheMoney;
    public bool itemTastetsGood;
    private int money;
    public int countedMoney;
    
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    public Transform theTable;
    private bool hasItem;
    public bool itemIsPlaced;
    private bool isInstantiated;
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
    private GameObject _newBurgerWish;
    private GameObject _newSodaWish;
    private GameObject _newPommesWish;
    private GameObject _newChickenWish;
    private GameObject _newDrinkWish;
    private GameObject _newBeerWish;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        _hands = GetComponent<Hands>();
        countTheMoney = GetComponent<TMP_Text>();
        hasItem = true;
        itemIsPlaced = false;
        isWishing = false;
        eating = eatingTime;
        isInstantiated = false;
        itemTastetsGood = false;
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CustomerSatisfaction();
        FoodWishAttempt1();
        countedMoney = money;
        print(countedMoney);
        // countTheMoney.text = countedMoney.ToString();
    }
    
    private void CustomerSatisfaction()
    {
        if (Input.GetKeyDown("e"))
        {
            PlaceOnTable();
        }
    }
    
    private void PlaceOnTable()
    {
        Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(2f,3f), 0, foodLayer);
        // Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);

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
        Gizmos.DrawWireCube(transform.position, new Vector3(2f,3f));
        // Gizmos.DrawWireSphere(transform.position, 1.1f);
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
                if (isInstantiated == false)
                {
                    _newBurgerWish = Instantiate(FoodWishBurger, transform.position, Quaternion.identity);
                    isInstantiated = true;
                }

                if (itemIsPlaced)
                {
                    Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(2f,3f), 0, foodLayer);
                    // Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                    
                    foreach (var burger in food)
                    {
                        if (burger.gameObject.CompareTag("Burger"))
                        {
                            _newBurgerWish.gameObject.SetActive(false);
                            eating -= Time.deltaTime;
                            if (eating < 0)
                            {
                                itemTastetsGood = true;
                                burger.gameObject.SetActive(false);
                                print("yummy");
                                money += 5;
                                _npcMovement.foodFinished = true;
                                _npcMovement.isStillInBuilding = true;
                            }
                        }

                        // eating = eatingTime;
                    }
                }
                
            }

            if (_FoodItem == ListOfFoodStuff[1] && _npcMovement.isSitting)
            {
                if (isInstantiated == false)
                {
                    _newSodaWish = Instantiate(FoodWishSoda, transform.position, quaternion.identity);
                    isInstantiated = true;
                }

                if (itemIsPlaced)
                {
                    Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(2f,3f), 0, foodLayer);
                    // Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                    
                    foreach (var soda in food)
                    {
                        if (soda.gameObject.CompareTag("Soda"))
                        {
                            _newSodaWish.gameObject.SetActive(false);
                            eating -= Time.deltaTime;
                            if (eating < 0)
                            {
                                soda.gameObject.SetActive(false);
                                print("juicy");
                                money += 5;
                                _npcMovement.foodFinished = true;
                                _npcMovement.isStillInBuilding = true;
                            }
                        }

                        // eating = eatingTime;
                    }
                }
            }
            
            if (_FoodItem == ListOfFoodStuff[2] && _npcMovement.isSitting)
            {
                if (isInstantiated == false)
                {
                    _newPommesWish = Instantiate(FoodWishPommes, transform.position, quaternion.identity);
                    isInstantiated = true;
                }

                if (itemIsPlaced)
                {
                    Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(2f,3f), 0, foodLayer);
                    // Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                    
                    foreach (var pommes in food)
                    {
                        if (pommes.gameObject.CompareTag("Pommes"))
                        {
                            _newPommesWish.gameObject.SetActive(false);
                            eating -= Time.deltaTime;
                            if (eating < 0)
                            {
                                pommes.gameObject.SetActive(false);
                                print("Tasty");
                                money += 5;
                                _npcMovement.foodFinished = true;
                                _npcMovement.isStillInBuilding = true;
                            }
                        }

                        // eating = eatingTime;
                    }
                }
            }
            
            if (_FoodItem == ListOfFoodStuff[3] && _npcMovement.isSitting)
            {
                if (isInstantiated == false)
                {
                    _newChickenWish = Instantiate(FoodWishChicken, transform.position, quaternion.identity);
                    isInstantiated = true;
                }

                if (itemIsPlaced)
                {
                    Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(2f,3f), 0, foodLayer);
                    // Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                    
                    foreach (var chicken in food)
                    {
                        if (chicken.gameObject.CompareTag("Chicken"))
                        {
                            _newChickenWish.gameObject.SetActive(false);
                            eating -= Time.deltaTime;
                            if (eating < 0)
                            {
                                chicken.gameObject.SetActive(false);
                                print("Crispy");
                                money += 5;
                                _npcMovement.foodFinished = true;
                                _npcMovement.isStillInBuilding = true;
                            }
                        }

                        // eating = eatingTime;
                    }
                }
            } 
            
            if (_FoodItem == ListOfFoodStuff[4] && _npcMovement.isSitting)
            {
                if (isInstantiated == false)
                {
                    _newDrinkWish = Instantiate(FoodWishDrink, transform.position, quaternion.identity);
                    isInstantiated = true;
                }

                if (itemIsPlaced)
                {
                    Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(2f,3f), 0, foodLayer);
                    // Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                    
                    foreach (var Drink in food)
                    {
                        if (Drink.gameObject.CompareTag("Drink"))
                        {
                            _newDrinkWish.gameObject.SetActive(false);
                            eating -= Time.deltaTime;
                            if (eating < 0)
                            {
                                Drink.gameObject.SetActive(false);
                                print("Delicious");
                                money += 5;
                                _npcMovement.foodFinished = true;
                                _npcMovement.isStillInBuilding = true;
                            }
                        }

                        // eating = eatingTime;
                    }
                }
            }
            
            if (_FoodItem == ListOfFoodStuff[5] && _npcMovement.isSitting)
            {
                if (isInstantiated == false)
                {
                    _newBeerWish = Instantiate(FoodWishBeer, transform.position, quaternion.identity);
                    isInstantiated = true;
                }

                if (itemIsPlaced)
                {
                    Collider2D[] food = Physics2D.OverlapBoxAll(transform.position, new Vector2(2f,3f), 0, foodLayer);
                    // Collider2D[] food = Physics2D.OverlapCircleAll(transform.position, 1.1f, foodLayer);
                    
                    foreach (var beer in food)
                    {
                        if (beer.gameObject.CompareTag("Beer"))
                        {
                            _newBeerWish.gameObject.SetActive(false);
                            eating -= Time.deltaTime;
                            if (eating < 0)
                            {
                                beer.gameObject.SetActive(false);
                                print("strong Beer");
                                money += 5;
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
}

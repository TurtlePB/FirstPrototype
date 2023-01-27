using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Burger;
    public GameObject Soda;
    public GameObject Pommes;
    public GameObject Chicken;
    public GameObject Drink;
    public GameObject Beer;
    public bool existingBurger;
    public bool existingSoda;
    public bool existingPommes;
    public bool existingChicken;
    public bool existingDrink;
    public bool existingBeer;
    public Transform SpawnpointBurger;
    public Transform SpawnpointSoda;
    public Transform SpawnpointPommes;
    public Transform SpawnPointChicken;
    public Transform SpawnpointDrink;
    public Transform SpawnPointBeer;
    
    void Start()
    {
        existingBurger = false;
        existingSoda = false;
        existingPommes = false;
        existingChicken = false;
        existingDrink = false;
        existingBeer = false;
    }
    
    void Update()
    {
        SpawnFood();
    }

    private void SpawnFood()
    {
        if (existingBurger == false)
        {
            GameObject newBurger = Instantiate(Burger, SpawnpointBurger.position, Quaternion.identity); 
        
            newBurger.GetComponent<Burger>().SetSpawner(this);
            newBurger.transform.SetParent(transform);
            existingBurger = true;
        }
        
        if (existingSoda == false)
        {
            GameObject newSoda = Instantiate(Soda, SpawnpointSoda.position, quaternion.identity);
        
                newSoda.GetComponent<Soda>().SetSpawner(this);
                newSoda.transform.SetParent(transform);
                existingSoda = true;
        }

        if (existingPommes == false)
        {
            GameObject newPommes = Instantiate(Pommes, SpawnpointPommes.position, quaternion.identity);

            newPommes.GetComponent<Pommes>().SetSpawner(this);
            newPommes.transform.SetParent(transform);
            existingPommes = true;
        }

        if (existingChicken == false)
        {
            GameObject newChicken = Instantiate(Chicken, SpawnPointChicken.position, quaternion.identity);
            
            newChicken.GetComponent<Chicken>().SetSpawner(this);
            newChicken.transform.SetParent(transform);
            existingChicken = true;
        }

        if (existingDrink == false)
        {
            GameObject newDrink = Instantiate(Drink, SpawnpointDrink.position, quaternion.identity);
            
            newDrink.GetComponent<Drink>().SetSpawner(this);
            newDrink.transform.SetParent(transform);
            existingDrink = true;
        }

        if (existingBeer == false)
        {
            GameObject newBeer = Instantiate(Beer, SpawnPointBeer.position, quaternion.identity);
            
            newBeer.GetComponent<Beer>().SetSpawner(this);
            newBeer.transform.SetParent(transform);
            existingBeer = true;
        }
    }

    // public void SpawnAllKindOfFood()
    // {
    //     GameObject newFood1 = Instantiate(Burger, SpawnpointBurger.position, quaternion.identity);
    //     GameObject newFood2 = Instantiate(Soda, SpawnpointSoda.position, quaternion.identity);
    //     
    //     GetComponent<Food>().SetSpawner(this);
    //     
    //     newFood1.transform.SetParent(transform);
    //     newFood2.transform.SetParent(transform);
    //     
    // }
}

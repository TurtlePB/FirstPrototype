using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Burger;
    public GameObject Soda;
    public int existingBurger;
    public int existingSoda;
    public Transform SpawnpointBurger;
    public Transform SpawnpointSoda;
    
    void Start()
    {
        existingBurger = 0;
        existingSoda = 0;
    }
    
    void Update()
    {
        SpawnFood();
    }

    private void SpawnFood()
    {
        if (existingBurger == 0)
        {
            GameObject newBurger = Instantiate(Burger, SpawnpointBurger.position, Quaternion.identity); 

            newBurger.GetComponent<Burger>().SetSpawner(this);
            newBurger.transform.SetParent(transform);
            existingBurger = 1;
        }

        if (existingSoda == 0)
        {
            GameObject newSoda = Instantiate(Soda, SpawnpointSoda.position, quaternion.identity);

                newSoda.GetComponent<Soda>().SetSpawner(this);
                newSoda.transform.SetParent(transform);
                existingSoda = 1;
        }
    }
}

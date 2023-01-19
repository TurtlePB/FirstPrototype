using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodWishBurger : MonoBehaviour
{
    private Table _foodwish;
    private SpriteRenderer sr;

    public void SetSpawner(Table foodWishSpawner)
    {
        _foodwish = foodWishSpawner;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

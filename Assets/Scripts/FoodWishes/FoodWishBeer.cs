using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodWishBeer : MonoBehaviour
{
    private Table _table;

    public void SetSpawner(Table foodWishBeerSpawner)
    {
        _table = foodWishBeerSpawner;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodWishDrink : MonoBehaviour
{
    private Table _table;

    public void SetSpawner(Table foodWishDrinkSpawner)
    {
        _table = foodWishDrinkSpawner;
    }
}

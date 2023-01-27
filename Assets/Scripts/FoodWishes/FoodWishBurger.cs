using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodWishBurger : MonoBehaviour
{
    private Table _table;

    public void SetSpawner(Table foodWishBurgerSpawner)
    {
        _table = foodWishBurgerSpawner;
    }
}

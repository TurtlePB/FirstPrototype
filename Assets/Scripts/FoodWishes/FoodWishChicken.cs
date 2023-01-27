using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodWishChicken : MonoBehaviour
{
    private Table _table;

    public void SetSpawner(Table foodWishChickenSpawner)
    {
        _table = foodWishChickenSpawner;
    }
}

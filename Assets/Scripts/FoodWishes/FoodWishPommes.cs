using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodWishPommes : MonoBehaviour
{
    private Table _table;

    public void SetSpawner(Table foodWishPommesSpawner)
    {
        _table = foodWishPommesSpawner;
    }
}

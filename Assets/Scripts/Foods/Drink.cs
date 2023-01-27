using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    private Spawner _spawner;

    public void SetSpawner(Spawner drinkSpawner)
    {
        _spawner = drinkSpawner;
    }
}

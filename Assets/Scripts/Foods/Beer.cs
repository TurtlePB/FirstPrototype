using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : MonoBehaviour
{
    private Spawner _spawner;

    public void SetSpawner(Spawner beerSpawner)
    {
        _spawner = beerSpawner;
    }
}

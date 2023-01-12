using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Spawner _spawner;

    public void SetSpawner(Spawner foodSpawner)
    {
        _spawner = foodSpawner;
    }
}

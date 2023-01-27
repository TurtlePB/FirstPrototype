using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private Spawner _spawner;

    public void SetSpawner(Spawner chickenSpawner)
    {
        _spawner = chickenSpawner;
    }
}

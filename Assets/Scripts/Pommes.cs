using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pommes : MonoBehaviour
{

    private Spawner _spawner;

    public void SetSpawner(Spawner pommesSpawner)
    {
        _spawner = pommesSpawner;
    }
}

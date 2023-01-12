using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    private Spawner _spawner;
    
    public void SetSpawner(Spawner burgerSpawner)
    {
        _spawner = burgerSpawner;
    }
}

// public partial class Food : MonoBehaviour
// {
//     private Spawner _spawner;
//
//     public void SetSpawner(Spawner foodSpawner)
//     {
//         _spawner = foodSpawner;
//     }
//
// }

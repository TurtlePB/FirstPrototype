using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda : MonoBehaviour
{
    private Spawner _spawner;

     public void SetSpawner(Spawner SodaSpawner)
     {
         _spawner = SodaSpawner;
     }
}

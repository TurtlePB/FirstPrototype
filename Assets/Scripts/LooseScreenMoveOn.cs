using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseScreenMoveOn : MonoBehaviour
{
    public string sceneName;
    private float looseStreetTimer = 2.2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        looseStreetTimer -= Time.deltaTime;
        if (looseStreetTimer <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

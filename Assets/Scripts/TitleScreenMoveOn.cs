using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenMoveOn : MonoBehaviour
{
    // public static LevelManager;
    private float titleStreetTimer = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        titleStreetTimer -= Time.deltaTime;
        if (titleStreetTimer <= 0)
        {
            // SceneManager.LoadScene(sceneName);
        }
    }
}

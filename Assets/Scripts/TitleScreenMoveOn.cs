using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenMoveOn : MonoBehaviour
{
    public string sceneName;
    private float titleStreetTimer = 1.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        titleStreetTimer -= Time.deltaTime;
        if (titleStreetTimer <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

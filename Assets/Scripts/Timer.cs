using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float levelTimer;
    public TMP_Text dingstimer;
    void Start()
    {
        levelTimer = 200;
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer -= Time.deltaTime;
        dingstimer.text = levelTimer.ToString("F0");
    }
    
    public void TimedOut()
    {
        // if (levelTimer <= 0)
        // {
        //     //TODO: Load next scene |Loose| or |Win| Scene
        // }
    }
}

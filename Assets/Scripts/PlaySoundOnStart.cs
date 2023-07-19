using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private Timer _timer;
    public int growlTimer;
    void Start()
    {
        growlTimer = Random.Range(0, 120);
    }

    private void Update()
    {
        if (_timer.levelTimer == growlTimer)
        {
            SoundManager.Instance.PlaySound(_clip);
            print("growl");
        }
    }
}

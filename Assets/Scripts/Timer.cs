using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float levelTimer;
    public TMP_Text dingstimer;
    public TMP_Text MouneyCounter;
    private Table _table;
    public string sceneName;
    private int money;
    // public SoundManager _SoundManager;
    void Start()
    {
        levelTimer = 120f;
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer -= Time.deltaTime;
        dingstimer.text = levelTimer.ToString("F0");
        if (levelTimer <= 0f && money >= 30)
        {
            SceneManager.LoadScene(sceneName);
        }

        if (levelTimer <= 0f && money <= 30)
        {
            SceneManager.LoadScene("LooseScene");
        }

        // if (levelTimer <= 20f)
        // {
        //     _SoundManager.
        // }
    }

    public void AddMoney(int amount)
    {
        money += amount;
        print(money);
        // MouneyCounter.text = money.ToString();
    }
}

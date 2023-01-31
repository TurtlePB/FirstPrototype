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
    void Start()
    {
        levelTimer = 30;
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer -= Time.deltaTime;
        dingstimer.text = levelTimer.ToString("F0");
        if (levelTimer <= 0 && money == 5)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void AddMoney(int amount)
    {
        money += amount;
        dingstimer.text = money.ToString();
    }
}

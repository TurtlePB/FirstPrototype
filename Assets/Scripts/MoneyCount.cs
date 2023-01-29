using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCount : MonoBehaviour
{
    private Table _table;
    public int money;
    public TMP_Text moneyText;
    void Start()
    {
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // MoneyText.SetText(Money.ToString());
        moneyText.text = money.ToString();
        // moneyText.text = _table.giveMoney.ToString();
    }

    private void converter()
    {
        // _table.giveMoney = money
    }
}

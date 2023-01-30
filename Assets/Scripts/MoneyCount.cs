using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCount : MonoBehaviour
{
    private Table _table;
    public TMP_Text _tmpro;
    void Start()
    {
        _table = GetComponent<Table>();
        _tmpro = GetComponent<TMP_Text>();
    }
    
    void Update()
    {
        _tmpro.text = _table.countedMoney.ToString();
    }
}

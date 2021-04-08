using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMoney, _textPerSecond;
    private long _money;

    private int _moneyForClick = 1, _moneyPerSecond;
    private string _moneyForClickKey = "MoneyForClick", _moneyKey = "Money", _moneyPerSecondKey = "MoneyPerSecond";

    private void OnEnable()
    {
        var moneyString = PlayerPrefs.GetString(_moneyKey);
        if(moneyString.Length > 0)
            _money = long.Parse(moneyString);
        _moneyForClick = PlayerPrefs.GetInt(_moneyForClickKey);
        _moneyPerSecond = PlayerPrefs.GetInt(_moneyPerSecondKey);
        _textMoney.text = _money + "$";
        _textPerSecond.text = _moneyPerSecond + "$";
        StartCoroutine(PerSecondUpdate());
    }

    private void AddMoney(long cash)
    {
        _money += cash;
        _textMoney.text = _money + "$";
        PlayerPrefs.SetString(_moneyKey, _money.ToString());
    }

    public void AddMoneyForClick()
    {
        AddMoney(_moneyForClick);
    }

    public void AddMoneyX100()
    {
        AddMoney(_moneyForClick * 100);
    }

    public void TryBuyForClick(int cost, int add, string name)
    {
        TryBuy(cost,add,name,_moneyForClickKey, ref _moneyForClick);
    }
    
    public void TryBuyPerSecond(int cost, int add, string name)
    {
        TryBuy(cost,add,name, _moneyPerSecondKey, ref _moneyPerSecond);
        _textPerSecond.text = _moneyPerSecond + "$";
    }

    private void TryBuy(int cost, int add, string name, string saveKey, ref int baseValue)
    {
        if (_money >= cost)
        {
            AddMoney(-cost);
            baseValue += add;
            PlayerPrefs.SetInt(name, PlayerPrefs.GetInt(name) + 1);
            PlayerPrefs.SetInt(saveKey, baseValue);
        }
    }

    private IEnumerator PerSecondUpdate()
    {
        while (true)
        {
            AddMoney(_moneyPerSecond);
            yield return new WaitForSeconds(1);
        }
    }
}

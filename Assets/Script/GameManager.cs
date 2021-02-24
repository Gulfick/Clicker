using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMoney;
    private long _money;

    private int _moneyForClick = 1;
    private string _moneyForClickKey = "MoneyForClick", _moneyKey = "Money";

    private void OnEnable()
    {
        _money = long.Parse(PlayerPrefs.GetString(_moneyKey));
        _moneyForClick = PlayerPrefs.GetInt(_moneyForClickKey);
        _textMoney.text = _money + "$";
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

    public void TryBuy(int cost, int add, string name)
    {
        if (_money >= cost)
        {
            AddMoney(-cost);
            _moneyForClick += add;
            PlayerPrefs.SetInt(name, PlayerPrefs.GetInt(name) + 1);
            PlayerPrefs.SetInt(_moneyForClickKey, _moneyForClick);
        }
    }
}

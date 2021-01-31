using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMoney;
    private long _money;

    private int _moneyForClick = 1;


    private void AddMoney(long cash)
    {
        _money += cash;
        _textMoney.text = _money + "$";
    }

    public void AddMoneyForClick()
    {
        AddMoney(_moneyForClick);
    }

    public void TryBuy(int cost, int add)
    {
        if (_money >= cost)
        {
            AddMoney(-cost);
            _moneyForClick += add;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    [SerializeField] private bool _isForClick;
    [SerializeField] private int _cost, _add, _maxCount;
    [SerializeField] private string _name, _description;
    [SerializeField] private Button _button;
    [SerializeField] private GameManager _manager;
    [SerializeField] private TextMeshProUGUI _nameText, _costText, _descriptionText, _buyedCountText;

    private int _startCost;
    
    private void Start()
    {
        if(_isForClick)
            _button.onClick.AddListener(BuyForClick);
        else 
            _button.onClick.AddListener(BuyPerSecond);

        _startCost = _cost;
        _nameText.text = _name;
        _costText.text = _cost + "$";
        _descriptionText.text = _description;
        CheckMaxCount();
    }

    private void BuyForClick()
    {
        _manager.TryBuyForClick(_cost, _add, _name);
        CheckMaxCount();
    }
    
    private void BuyPerSecond()
    {
        _manager.TryBuyPerSecond(_cost, _add, _name);
        CheckMaxCount();
    }

    private void CheckMaxCount()
    {
        var curCount = PlayerPrefs.GetInt(_name);
        _buyedCountText.text = curCount.ToString();
        if (curCount >= _maxCount)
        {
            _button.interactable = false;
        }

        if (curCount == 0)
            return;
        
        _cost = Mathf.RoundToInt(Mathf.Pow(1.15f, curCount) * _startCost);
        _costText.text = _cost + "$";
    }
}

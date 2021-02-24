using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    [SerializeField] private int _cost, _add, _maxCount;
    [SerializeField] private string _name, _description;
    [SerializeField] private Button _button;
    [SerializeField] private GameManager _manager;
    [SerializeField] private TextMeshProUGUI _nameText, _costText, _descriptionText, _buyedCountText;
    
    private void Start()
    {
        _button.onClick.AddListener(Buy);
        _nameText.text = _name;
        _costText.text = _cost + "$";
        _descriptionText.text = _description;
        CheckMaxCount();
    }

    private void Buy()
    {
        _manager.TryBuy(_cost, _add, _name);
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
    }
}

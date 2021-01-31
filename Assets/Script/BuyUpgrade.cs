using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    [SerializeField] private int _cost, _add;
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
    }

    private void Buy()
    {
        _manager.TryBuy(_cost,_add);
    }
}

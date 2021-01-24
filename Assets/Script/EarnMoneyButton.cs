using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnMoneyButton : MonoBehaviour
{
    [SerializeField] private GameManager _manager;
    
    public void ButtonClick()
    {
        _manager.AddMoneyForClick();
    }
}

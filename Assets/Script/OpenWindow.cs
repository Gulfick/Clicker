using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWindow : MonoBehaviour
{
    [SerializeField] private GameObject _window;

    public void Open()
    {
        _window.SetActive(true);
    }

    public void Close()
    {
        _window.SetActive(false);
    }

    public void ToggleOpen()
    {
        if(_window.activeSelf)
            Close();
        else
            Open();
    }
}

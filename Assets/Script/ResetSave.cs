using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSave : MonoBehaviour
{
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("MoneyForClick", 1);
        SceneManager.LoadScene(0);
    }
}

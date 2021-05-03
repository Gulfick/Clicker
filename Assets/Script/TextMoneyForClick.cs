using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextMoneyForClick : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CanvasGroup _canvasGroup;

    private float _lifeTime = 4;
    
    
    public void Spawn(int money)
    {
        _text.text = $"+{money}$";
        _canvasGroup.DOFade(0, _lifeTime);
        var trans = transform;
        var endPos = trans.position;
        endPos.y += 110;
        trans.DOMove(endPos, _lifeTime);
        StartCoroutine(DestroyOnEnd());
    }

    private IEnumerator DestroyOnEnd()
    {
        yield return new WaitForSeconds(_lifeTime + 0.1f);
        Destroy(gameObject);
    }
}

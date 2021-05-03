using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class EarnMoneyButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
{
    [SerializeField] private GameManager _manager;
    [SerializeField] private AudioSource _sourceClick;

    private RectTransform _transform;

    private void Start()
    {
        _transform = GetComponent<RectTransform>();
    }

    public void ButtonClick()
    {
        _manager.AddMoneyForClick();
        _sourceClick.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _transform.DOScale(Vector3.one, 0.1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
        ButtonClick();
    }
}

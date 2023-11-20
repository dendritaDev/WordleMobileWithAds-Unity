using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TweeningFill2 : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image FillImage;
    [SerializeField] private TextMeshProUGUI TMP;
    [SerializeField] private Color RollOverTextColor;

    private Color BaseTextColor;

    protected override void Start()
    {
        base.Start();
        FillImage.rectTransform.sizeDelta = Vector2.zero;
        BaseTextColor = TMP.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FillImage.rectTransform.DOSizeDelta(new Vector2(74.3f, 100.2f), 0.25f)
            .SetEase(Ease.OutCubic)
            .SetLink(gameObject)
            .Play();

        TMP.DOColor(RollOverTextColor, 0.25f).SetLink(gameObject).Play();

    }


    public void OnPointerExit(PointerEventData eventData)
    {
        FillImage.rectTransform.DOSizeDelta(Vector2.zero, 0.25f)
           .SetEase(Ease.OutCubic)
           .SetLink(gameObject)
           .Play();

        TMP.DOColor(BaseTextColor, 0.25f).SetLink(gameObject).Play();
    }
}

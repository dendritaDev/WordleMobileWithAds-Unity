using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TweeningFill1 : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image FillImage;
    [SerializeField] private TextMeshProUGUI TMP;
    [SerializeField] private Color RollOverTextColor;

    private Color BaseTextColor;

    protected override void Start()
    {
        base.Start();
        FillImage.fillAmount = 0;
        BaseTextColor = TMP.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FillImage.DOFillAmount(1f, 0.25f).SetEase(Ease.OutCubic).Play();
        TMP.DOColor(RollOverTextColor, 0.25f).Play();
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        
        FillImage.DOFillAmount(0f, 0.25f).SetEase(Ease.OutCubic).Play();
        TMP.DOColor(BaseTextColor, 0.25f).Play();
    }
}

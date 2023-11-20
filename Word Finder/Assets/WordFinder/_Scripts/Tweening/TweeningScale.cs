using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class TweeningScale : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float Rate;
    private Vector3 BaseScale;

    protected override void Start()
    {
        base.Start();
        BaseScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(BaseScale * Rate, 0.25f)
            .SetEase(Ease.OutBounce)
            .Play();
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(BaseScale, 0.25f)
            .SetEase(Ease.OutBounce)
            .Play();
    }
}

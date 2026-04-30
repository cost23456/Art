using UnityEngine;
using DG.Tweening;

public class bg : MonoBehaviour
{
    private CanvasGroup CanvasGroup;
    private Sequence mDO;
    private void Awake()
    {
        this.CanvasGroup = GetComponent<CanvasGroup>();
    }
    private void OnEnable()
    {
        if (CanvasGroup != null)
        {
            this.mDO?.Kill(true);
            this.mDO = DOTween.Sequence();
            this.CanvasGroup.alpha = 0f;
            this.mDO.Append(this.CanvasGroup.DOFade(1f, 0.5f).SetEase(Ease.InOutSine));
            this.mDO.Append(this.CanvasGroup.DOFade(0f, 0.5f).SetEase(Ease.InOutSine));
        }
    }
}

using DG.Tweening;
using UnityEngine;

public class Promote : MonoBehaviour
{
    private Sequence mDo;
    private CanvasGroup mCanvas;
    private void OnEnable()
    {
        this.mCanvas = GetComponent<CanvasGroup>();
        this.mDo = DOTween.Sequence();
        this.transform.localScale = Vector3.zero;
        this.mDo.Append(this.transform.DOScale(new Vector3(1f,1f,1f),0.5f)).AppendInterval(5f);
        this.mCanvas.alpha = 1f;
        this.mDo.Append(this.mCanvas.DOFade(0f,5f));
        this.mDo.OnComplete(() =>
        {
            this.gameObject.SetActive(false);
        });
    }
}

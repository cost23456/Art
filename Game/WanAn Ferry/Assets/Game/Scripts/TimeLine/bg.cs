using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Diagnostics.CodeAnalysis;

public class bg : MonoBehaviour
{
    public string Book;
    public Text LastText;
    private CanvasGroup CanvasGroup;
    private Sequence mDO;
    public Animator Bridge;
    public Cinemachine.CinemachineBrain cinemachineBrain;
    private bool isOver = false;
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
            this.mDO.Append(this.CanvasGroup.DOFade(1f, 1f).SetEase(Ease.InOutSine));
            //this.mDO.Append(this.LastText.DOText(this.Book, 3f));
        }
    }
    private void Update()
    {
        if (Input.anyKeyDown && isOver == false)
        {
            this.isOver = true;
            this.Bridge.SetTrigger("GameOver");
            this.cinemachineBrain.enabled = false;
            UIManager.Instance.ContrlIconPage();
            UIManager.Instance.OpenTaskLittle();
            Destroy(this.gameObject);
        }
    }
}

using DG.Tweening;
using System.Xml.Serialization;
using UnityEngine;

public class Promote : MonoBehaviour
{
    private Sequence mDo;
    private CanvasGroup mCanvas;
    public DirectorContrl Direct0r;
    public float Time = 5f;
    private void OnEnable()
    {
        this.Direct0r = FindObjectOfType<DirectorContrl>();
        this.mCanvas = GetComponent<CanvasGroup>();
        this.mDo = DOTween.Sequence();
        this.transform.localScale = Vector3.zero;
        this.mDo.Append(this.transform.DOScale(new Vector3(1f,1f,1f),0.5f)).AppendInterval(5f);
        this.mCanvas.alpha = 1f;
        this.mDo.Append(this.mCanvas.DOFade(0f,Time));
        this.mDo.OnComplete(() =>
        {
            this.gameObject.SetActive(false);
        });
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
        }
    }
    public void PlayDire()
    {
        this.Direct0r.ContrlDirectors(0);
    }
}

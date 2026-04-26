using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class StartGame : MonoBehaviour
{
    public AudioClip ForeGame;
    public AudioClip DialogClip;
    public AudioClip BGMClip;
    public List<CanvasGroup> Group1;
    public List<CanvasGroup> Group2;
    private CanvasGroup Mycanvas;
    public List<Text> Texts1 = new List<Text>();
    public List<Text> Texts2 = new List<Text>();
    public List<string> Dialog1;
    public List<float> ShowTime1;
    public List<string> Dialog2;
    public List<float> ShowTime2;
    private int DialogIndex1 = 0;
    private int ShowTimeIndex1 = 0;
    private int DialogIndex2 = 0;
    private int ShowTimeIndex2 = 0; 
    private Sequence sequence;

    private void Awake()
    {
        this.Mycanvas = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        //AudioManager.Instance.PlayBGMAudio(ForeGame);
        this.sequence = DOTween.Sequence();
        this.DoAllText();
        float AllTime = 0f;
        foreach (float time in ShowTime2)
        {
            AllTime += time;
        }
        AllTime += 4f;
        StartCoroutine(PlayDialog(AllTime));
        foreach (float time in ShowTime1)
        {
            AllTime += time;
        }
        Destroy(gameObject, AllTime +10f);
    }
    private void OnDestroy()
    {
        AudioManager.Instance.PlayBGMAudio(BGMClip);
    }
    private void DoAllText()
    {
        this.sequence?.Kill(true);
        this.sequence = DOTween.Sequence();
        foreach (Text text in Texts2)
        {
            this.sequence.Append(Group2[DialogIndex2].DOFade(1, 0.5f));
            this.sequence.Append(text.DOText(Dialog2[DialogIndex2], ShowTime2[ShowTimeIndex2]));
            this.sequence.Append(Group2[DialogIndex2].DOFade(0, 0.5f));
            this.DialogIndex2++;
            this.ShowTimeIndex2++;
        }
        foreach (Text text in Texts1)
        {
            this.sequence.Append(Group1[DialogIndex1].DOFade(1, 0.5f));
            this.sequence.Append(text.DOText(Dialog1[DialogIndex1], ShowTime1[ShowTimeIndex1]));
            this.sequence.Append(Group1[DialogIndex1].DOFade(0, 0.5f));
            this.DialogIndex1++;
            this.ShowTimeIndex1++;
        }
        this.sequence.Append(Mycanvas.DOFade(0, 1.5f));
    }
    IEnumerator PlayDialog(float Times)
    {
        yield return new WaitForSeconds(Times);
        AudioManager.Instance.PlayFXAudio(DialogClip);
        yield return new WaitForSeconds(36.8f);
        AudioManager.Instance.BGM.Stop();
    }
}

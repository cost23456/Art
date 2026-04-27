using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class bg : MonoBehaviour
{
    private CanvasGroup CanvasGroup;
    private void Awake()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
    }
    private void OnEnable()
    {
        if (CanvasGroup != null)
        {
            Debug.Log("OnEnable 被调用了"); // 添加这行，确认函数是否执行
            Debug.Log($"CanvasGroup 是否为空: {CanvasGroup == null}"); // 检查组件是否存在
            CanvasGroup.alpha = 0f;
            CanvasGroup.DOFade(1f, 1f).SetEase(Ease.InOutSine);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_1 : MonoBehaviour
{
    //参数
    private int NPC_ID = 1;
    //组件
    public List<AudioClip> RecieveTaskAudio;
    public List<AudioClip> FinshTaskAudio;
    //生命周期
    private void OnTriggerEnter(Collider other)
    {
        UIManager.Instance.ContrlDialogPage();
        if (TaskManager.Instance.JudgeTaskFinsh(NPC_ID))
        {
            UIManager.Instance.mDialog.Init(2);
            UIManager.Instance.mDialog.GetAudioFormNPC(FinshTaskAudio);
            Debug.Log("FinshTaskAudio");
        }
        else if (TaskManager.Instance.JudgeTaskReceive(NPC_ID) == false)
        {
            UIManager.Instance.mDialog.Init(NPC_ID);
            UIManager.Instance.mDialog.GetAudioFormNPC(RecieveTaskAudio);
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.ActiveTask();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (UIManager.Instance.mDialog.gameObject.activeSelf == false)
        {
            if (UIManager.Instance.mDialog.isDialogCompleted == true)
            {
                this.ActiveTask();
            }
            else
            {
                return;
            }
        }
        else if (UIManager.Instance.mDialog.gameObject.activeSelf == true)
        {
            UIManager.Instance.ContrlDialogPage();
        }
    }
    //方法
    public void ActiveTask()
    {
        // 新增：判断TaskManager单例是否为空
        if (TaskManager.Instance == null)
        {
            Debug.LogError("TaskManager 单例为空！");
            return;
        }
        // 执行任务
        TaskManager.Instance.SetActiveTask(1);
        // 新增：判断EventManager是否初始化（静态事件无需实例，但静态方法需要初始化）
        EventManager.OnSetActiveTask(1);
    }
}
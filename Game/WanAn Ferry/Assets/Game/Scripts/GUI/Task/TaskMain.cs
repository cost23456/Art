using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaskMain : MonoBehaviour
{
    //组件
    private TaskElementDesc mEleDesc;
    private TaskElementAtt mEleAtt;
    private TaskElementReward mEleReward;
    private TaskEleLittle mEleLittle;
    //参数
    private TaskData mCurTask;
    private void Awake()
    {
        this.mEleDesc = this.transform.Find("Main/Task_DESC").GetComponent<TaskElementDesc>();
        this.mEleAtt = this.transform.Find("Main/Task_Attention").GetComponent<TaskElementAtt>();
        this.mEleReward = this.transform.Find("Main/Task_Reward").GetComponent<TaskElementReward>();
        this.mEleLittle = this.transform.Find("LittleTask").GetComponent <TaskEleLittle>();
    }
    private void Start()
    {
        //事件
        EventManager.ON_SETACTIVE_TASK += this.RefreshTaskText;
        EventManager.ON_FINISHTASK += this.RefreshTaskText;
    }
    //方法
    private void RefreshTaskText(int aIndex)
    {
        this.mCurTask = TaskManager.GetSingleton().GetTask(aIndex);
        this.mEleDesc.RefreshAll(mCurTask);
        this.mEleReward.RefreshAll(mCurTask);
        this.mEleAtt.RefreshAll(mCurTask);
        this.mEleLittle.RefreshAll(mCurTask);
    }

}

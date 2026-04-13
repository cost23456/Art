using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaskMain : MonoBehaviour
{
    //组件
    [UseReflection("Task_DESC")]private TaskElementDesc mEleDesc;
    [UseReflection("Task_Attention")]private TaskElementAtt mEleAtt;
    [UseReflection("Task_Reward")]private TaskElementReward mEleReward;
    //参数
    private TaskData mCurTask;
    private void Awake()
    {
        //this.mEleDesc = this.transform.Find("Task_DESC").GetComponent<TaskElementDesc>();
        //this.mEleAtt = this.transform.Find("Task_Attention").GetComponent<TaskElementAtt>();
        //this.mEleReward = this.transform.Find("Task_Reward").GetComponent<TaskElementReward>();
    }
    private void Start()
    {
        GameObjectReflectionBinder.BindGameObjects(this);
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
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskEleLittle : MonoBehaviour
{
    private Text mTest;

    private void Awake()
    {
        this.mTest = this.transform.Find("Desc").GetComponent<Text>();
    }
    public void RefreshAll(TaskData curTask)
    {
        if (curTask == null)
        {
            Debug.Log("curTask == null");
            this.mTest.text = "当前无任务";
            return;
        }
        //判断刷新逻辑
        if (curTask.isReceive && curTask.isSuccess == false)
        {
            this.mTest.text = curTask.Task_Desc.ToString();
        }
        else if (curTask.isSuccess)
        {
            this.mTest.text = "任务已完成";
        }
    }
}

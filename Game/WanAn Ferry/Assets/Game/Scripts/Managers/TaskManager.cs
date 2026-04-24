using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : Singleton<TaskManager>
{
    public List<TaskData> taskDatas;
    
    //获取任务数据
    public TaskData GetTask(int aTask_ID)
    {
        foreach (TaskData task in taskDatas)
        {
            if (aTask_ID == task.Task_ID)
            {
                return task;
            }
        }
        Debug.Log("没有相对应的任务");
        return null;
    }
    //判断任务是否完成
    public bool JudgeTaskFinsh(int aTask_ID)
    {
        foreach (var task in taskDatas)
        {
            if (aTask_ID == task.Task_ID)
            {
                return task.isSuccess;
            }
        }
        Debug.Log("没有相对应的任务");
        return false;
    }
    //判断任务是否领取
    public bool JudgeTaskReceive(int aTask_ID)
    {
        foreach (var task in taskDatas)
        {
            if (aTask_ID == task.Task_ID)
            {
                return task.isReceive;
            }
        }
        Debug.Log("没有相对应的任务");
        return false;
    }
    //判断当前任务
    public TaskData JudgeCurTask()
    {
        foreach (var task in taskDatas)
        {
            if (task.isReceive)
            {
                 return task;    
            }
        }
        Debug.Log("没有相对应的任务");
        return null;
    }
    //激活任务
    public void SetActiveTask(int aTask_ID)
    {
        foreach (var task in taskDatas)
        {
            if (aTask_ID == task.Task_ID)
            {
                task.isReceive = true;
                return;
            }
        }
        Debug.Log("没有相对应的任务");
    }
    //完成任务
    public void SetFinishTask(int aTask_ID)
    {
        foreach (var task in taskDatas)
        {
            if (aTask_ID == task.Task_ID && task.isReceive)
            {
                task.isSuccess = true;
                return;
            }
        }
        Debug.Log("没有相对应的任务");
    }
}
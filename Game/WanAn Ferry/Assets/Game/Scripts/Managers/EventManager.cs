using System;
using Unity.VisualScripting;
public static class EventManager 
{
    //注册事件
    public static event Action<int> ON_SETACTIVE_TASK; //接受任务
    public static event Action<int> ON_FINISHTASK; //完成任务
    //执行事件函数
    public static void OnSetActiveTask(int Task_ID)
    {
        ON_SETACTIVE_TASK?.Invoke(Task_ID);
    }
    public static void OnFinishTask(int Task_ID)
    {
        ON_FINISHTASK?.Invoke(Task_ID);
    }
}

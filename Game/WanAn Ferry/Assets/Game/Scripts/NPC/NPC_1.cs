using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_1 : MonoBehaviour
{
    //参数
    //组件

    //生命周期
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.ActiveTask();
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
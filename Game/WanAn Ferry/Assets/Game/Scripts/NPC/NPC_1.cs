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
        TaskManager.GetSingleton().SetActiveTask(1);
        EventManager.OnSetActiveTask(1);
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaskItem : MonoBehaviour
{
    public TaskItemData mItemData;
    //生命周期
    private void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        //TODO：打开UI
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(this.gameObject);
            TaskManager.Instance.SetFinishTask(mItemData.TaskItemData_ID);
            EventManager.OnFinishTask(1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //TODO：关闭UI
    }
    private void OnDestroy()
    {
    }
}

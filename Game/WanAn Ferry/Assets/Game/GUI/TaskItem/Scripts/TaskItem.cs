using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaskItem : MonoBehaviour
{
    public TaskItemData mItemData;
    public int TaskReward_ID;
    //ÉúÃüÖÜÆÚ
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(this.gameObject);
            TaskManager.Instance.SetFinishTask(mItemData.TaskItemData_ID);
            EventManager.OnFinishTask(mItemData.TaskItemData_ID);
        }
    }
    private void OnDestroy()
    {
        BagManager.Instance.AddBagItem(TaskReward_ID);
    }
}

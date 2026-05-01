
using UnityEngine;

public class TaskItem : MonoBehaviour
{
    public TaskItemData mItemData;
    public GameObject MainObject;
    public int TaskReward_ID;
    //ÉúÃüÖÜÆÚ
    private void Update()
    {
        if (TaskManager.Instance.JudgeTaskFinsh((mItemData.TaskItemData_ID)))
        {
            return;
        }
        if (TaskManager.Instance.JudgeTaskReceive(mItemData.TaskItemData_ID) && MainObject != null)
        {
            this.MainObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(this.gameObject);
            TaskManager.Instance.SetFinishTask(mItemData.TaskItemData_ID);
            EventManager.OnFinishTask(mItemData.TaskItemData_ID);
            BagManager.Instance.AddBagItem(TaskReward_ID);
            UIManager.Instance.ContrlPromote(7);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskElementReward : MonoBehaviour
{
    [UseReflection("RewardText")]private TextMeshProUGUI mRewardText;
    private void Awake()
    {
        //this.mRewardText = this.transform.Find("RewardText").GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        GameObjectReflectionBinder.BindGameObjects(this);
    }
    public void RefreshAll(TaskData curTask)
    {
        if (curTask == null)
        {
            Debug.Log("curTask == null");
            return;
        }
        //ÅÐ¶ÏË¢ÐÂÂß¼­
        if (curTask.isReceive && curTask.isSuccess == false)
        {
            this.mRewardText.text = curTask.Task_Reward.ToString();
        }
        else if (curTask.isSuccess)
        {
            this.mRewardText.text = curTask.Reward_Info[2].ToString();
        }
    }
}

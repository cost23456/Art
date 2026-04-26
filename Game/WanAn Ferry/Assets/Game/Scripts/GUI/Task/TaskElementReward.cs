using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TaskElementReward : MonoBehaviour
{
    [UseReflection("RewardText")]private Text mRewardText;
    private void Awake()
    {
        this.mRewardText = this.transform.Find("RewardText").GetComponent<Text>();
    }
    public void RefreshAll(TaskData curTask)
    {
        if (curTask == null)
        {
            Debug.Log("curTask == null");
            return;
        }
        if (mRewardText == null)
        {
            this.mRewardText = this.transform.Find("DescText").GetComponent<Text>();
        }
        //ÅÐ¶ÏË¢ÐÂÂß¼­
        if (curTask.isReceive && curTask.isSuccess == false)
        {
            this.mRewardText.text = curTask.Task_Reward.ToString();
        }
        else if (curTask.isSuccess)
        {
            //this.mRewardText.text = curTask.Reward_Info[2].ToString();
        }
    }
}

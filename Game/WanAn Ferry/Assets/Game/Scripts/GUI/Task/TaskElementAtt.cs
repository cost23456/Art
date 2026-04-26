using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TaskElementAtt : MonoBehaviour
{
    [UseReflection("AttText")]private Text mAttText;
    private void Awake()
    {
        this.mAttText = this.transform.Find("AttText").GetComponent<Text>();
    }
    public void RefreshAll(TaskData curTask)
    {
        if (curTask == null)
        {
            Debug.Log("curTask == null");
            return;
        }
        if (mAttText == null)
        {
            this.mAttText = this.transform.Find("DescText").GetComponent<Text>();
        }
        //ÅÐ¶ÏË¢ÐÂÂß¼­
        if (curTask.isReceive && curTask.isSuccess == false)
        {
            this.mAttText.text = curTask.Task_Attention.ToString();
        }
        else if (curTask.isSuccess)
        {
            //this.mAttText.text = curTask.Reward_Info[1].ToString();
        }
    }
}

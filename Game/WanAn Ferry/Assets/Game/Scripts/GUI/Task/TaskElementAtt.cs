using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskElementAtt : MonoBehaviour
{
    [UseReflection("AttText")]private TextMeshProUGUI mAttText;
    private void Awake()
    {
        //this.mAttText = this.transform.Find("AttText").GetComponent<TextMeshProUGUI>();
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
            this.mAttText.text = curTask.Task_Attention.ToString();
        }
        else if (curTask.isSuccess)
        {
            this.mAttText.text = curTask.Reward_Info[1].ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskElementDesc : MonoBehaviour
{
    [UseReflection("DescText")]private TextMeshProUGUI mDescText;
    private void Awake()
    {
        //this.mDescText = this.transform.Find("DescText").GetComponent<TextMeshProUGUI>();
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
            this.mDescText.text = curTask.Task_Desc.ToString();
        }
        else if (curTask.isSuccess)
        {
            this.mDescText.text = curTask.Reward_Info[0].ToString();
        }
    }
}

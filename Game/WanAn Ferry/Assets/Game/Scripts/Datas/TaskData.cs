using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTaskData", menuName = "GameData/TaskData", order = 1)]
public class TaskData : ScriptableObject
{
    public int Task_ID = 0;
    public string Task_Desc = null;
    public string Task_Attention = null;
    public string Task_Reward = null;
    public List<string> Reward_Info;
    public List<int> Item_ID;
    public List<int> Item_Count;
    public bool isSuccess = false;
    public bool isReceive = false;
}
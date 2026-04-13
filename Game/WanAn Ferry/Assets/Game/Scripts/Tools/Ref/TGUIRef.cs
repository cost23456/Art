using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGUIRef : MonoBehaviour
{
    public List<GameObject> RefList;
    public GameObject GetRef(int aIndex)
    {
        if (RefList[aIndex] == null)
        {
            Debug.Log("该物体不存在");
            return null;
        }
        return RefList[aIndex];
    }
}

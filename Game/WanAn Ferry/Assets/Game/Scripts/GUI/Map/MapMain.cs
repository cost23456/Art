using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class MapMain : MonoBehaviour
{
    //参数
    public float offset_x;
    public float offset_y;
    //组件
    public RectTransform Map;
    //生命周期
    private void Start()
    {
        this.Map = this.transform.Find("mini/Image").gameObject.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (Map != null)
        if (Input.GetKey(KeyCode.A))
        {
           this.Map.Translate(offset_x, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.Map.Translate(-offset_x, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.Map.Translate(0, -offset_y, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.Map.Translate(0,offset_y, 0);
        }
    }
    //方法
    //携程
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main: MonoBehaviour
{
    public void Seting()
    {
        this.gameObject.SetActive(false);
        GameObject seting = GameObject.FindGameObjectWithTag("Set").transform.gameObject;
        seting.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void OnClose()
    {
        this.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //参数
    public GameObject CurUIPage = null;
    public GameObject LastUIPage = null;
    //组件
    public Main mMainMenu;
    public Seting mSetting;
    public TaskMain mTaskMenu;
    public BagManager mBag;
   
    //生命周期
    //方法
    public void ContrlMainPage()
    {
        if (mMainMenu == null) return;
        if (mMainMenu.gameObject.activeSelf == false)
        {
            this.mMainMenu.gameObject.SetActive(true);
        }
        else if (mMainMenu.gameObject.activeSelf == true)
        {
            this.mMainMenu.gameObject.SetActive(false);
        }
    }
    public void ContrlSettingPage()
    {
        if (mSetting == null) return;
        if (mSetting.gameObject.activeSelf == false)
        {
            this.mSetting.gameObject.SetActive(true);
        }
        else if (mSetting.gameObject.activeSelf == true)
        {
            this.mSetting.gameObject.SetActive(false);
        }
    }
    public void ContrlTaskPage()
    {
        if (mTaskMenu == null) return;
        if (mTaskMenu.gameObject.activeSelf == false)
        {
            this.mTaskMenu.gameObject.SetActive(true);
        }
        else if (mTaskMenu.gameObject.activeSelf == true)
        {
            this.mTaskMenu.gameObject.SetActive(false);
        }
    }
    public void ContrlBagPage()
    {
        if (mBag == null) return;
        if (mBag.gameObject.activeSelf == false)
        {
            this.mBag.gameObject.SetActive(true);
        }
        else if (mBag.gameObject.activeSelf == true)
        {
            this.mBag.gameObject.SetActive(false);
        }
    }
    
}
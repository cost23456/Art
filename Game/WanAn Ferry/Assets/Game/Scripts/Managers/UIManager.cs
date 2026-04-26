using DG.Tweening;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.Infinity;

public class UIManager : Singleton<UIManager>
{
    //参数
    public GameObject CurUIPage = null;
    public GameObject LastUIPage = null;
    private bool isTaskMove = false;
    private bool isBagOpen = false;
    //组件
    public Main mMainMenu;
    public Seting mSetting;
    public GameObject mTaskMenu;
    public GameObject mTaskLittle;
    public BagManager mBag;
    public wenbenchat mDialog;
    public GameObject mMap;
    public GameObject mMapLittle;
    public GameObject mLoad;
    public CameraControl mMainCamera;
    public GameObject Icon;
    public List<GameObject> mTips;
    //生命周期
    private void Update()
    {
        if (mMainCamera == null )
        {
            this.mMainCamera = FindObjectOfType<CameraControl>();
        }
        //UI按键
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            this.ContrlTaskPage();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            this.ContrlBagPage();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            this.ContrlMapPage();
        }
    }
    //方法

    // 打开 UI 时显示鼠标 + 解锁
    void ShowCursorForUI(bool show)
    {
        if (show)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
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
        this.isTaskMove = !this.isTaskMove;
        if (isTaskMove)
        {
            this.mTaskMenu.transform.GetComponent<RectTransform>().DOAnchorPosY(0, 0.5f);
            this.mMainCamera.enabled = false;
        }
        else if (!isTaskMove)
        {
            this.mTaskMenu.transform.GetComponent<RectTransform>().DOAnchorPosY(900, 0.5f);
            this.mMainCamera.enabled = true;
        }
    }
    public void OpenTaskLittle()
    {
        this.mTaskLittle.SetActive(true);
    }
    public void ContrlBagPage()
    {
        if (mBag == null) return;
        this.isBagOpen = !this.isBagOpen;
        if (isBagOpen == false) 
        {
            this.mBag.transform.GetComponent<RectTransform>().DOAnchorPosX(0, 0.5f);
            this.mBag.PlayAudio();
            this.ShowCursorForUI(true);
        }
        else  if (isBagOpen == true)
        {
            this.mBag.transform.GetComponent<RectTransform>().DOAnchorPosX(-1920, 0.5f);
            this.ShowCursorForUI(false);
        }
    }
    public void ContrlDialogPage()
    {
        if (mDialog == null) return;
        if (mDialog.gameObject.activeSelf == false)
        {
            this.mDialog.gameObject.SetActive(true);
        }
        else if (mDialog.gameObject.activeSelf == true)
        {
            this.mDialog.gameObject.SetActive(false);
        }
    }
    public void ContrlMapPage()
    {
        if (mMap == null) return;
        if (mMap.gameObject.activeSelf == false)
        {
            this.mMap.gameObject.SetActive(true);
            this.ShowCursorForUI(true);
        }
        else if (mMap.gameObject.activeSelf == true)
        {
            this.mMap.gameObject.SetActive(false);
            this.ShowCursorForUI(false);
        }
    }
    public void ContrlMapLitPage()
    {
        if (mMapLittle == null) return;
        if (mMapLittle.gameObject.activeSelf == false)
        {
            this.mMapLittle.gameObject.SetActive(true);
        }
        else if (mMapLittle.gameObject.activeSelf == true)
        {
            this.mMapLittle.gameObject.SetActive(false);
        }
    }
    public void ContrlLoadPage()
    {
        if (mLoad == null) return;
        if (mLoad.gameObject.activeSelf == false)
        {
            this.mLoad.gameObject.SetActive(true);
        }
        else if (mLoad.gameObject.activeSelf == true)
        {
            this.mLoad.gameObject.SetActive(false);
        }
    }
    public void ControlTips(int aIndex)
    {
        if (mTips[aIndex] == null) return;
        if (mTips[aIndex].gameObject.activeSelf == false)
        {
            this.mTips[aIndex].gameObject.SetActive(true);
        }
        else if (mTips[aIndex].gameObject.activeSelf == true)
        {
            this.mTips[aIndex].gameObject.SetActive(false);
        }
    }
    public void ContrlIconPage()
    {
        if(Icon ==  null) return;
        if (Icon.gameObject.activeSelf == false)
        {
            this.Icon.SetActive(true);
        }
        else if (Icon.gameObject.activeSelf == true)
        {
            this.Icon.SetActive(false);
        }
    }
}
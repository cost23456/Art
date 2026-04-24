using DG.Tweening;
using System.Collections.Specialized;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    //参数
    public GameObject CurUIPage = null;
    public GameObject LastUIPage = null;
    //组件
    public Main mMainMenu;
    public Seting mSetting;
    public GameObject mTaskMenu;
    public GameObject mTaskLittle;
    public BagManager mBag;
    public GameObject mDialog;
    private bool isTaskMove = false;
    private bool isBagOpen = false;
    //生命周期
    private void Update()
    {
        //UI按键
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            this.ContrlTaskPage();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            this.ContrlBagPage();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            this.ContrlDialogPage();
        }
    }
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
        this.isTaskMove = !this.isTaskMove;
        if (isTaskMove)
        {
            this.mTaskMenu.transform.GetComponent<RectTransform>().DOAnchorPosY(0, 0.5f);
        }
        else if (!isTaskMove)
        {
            this.mTaskMenu.transform.GetComponent<RectTransform>().DOAnchorPosY(900, 0.5f);
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
            this.mBag.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        }
        else  if (isBagOpen == true)
        {
            this.mBag.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
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
}
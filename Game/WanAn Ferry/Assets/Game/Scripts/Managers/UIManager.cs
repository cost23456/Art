using DG.Tweening;
using UnityEngine;

public class UIManager : MonoBehaviour
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
    private bool isTaskMove = false;
    //生命周期
    private void Update()
    {
        //UI按键
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            this.ContrlTaskPage();
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
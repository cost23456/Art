using Cysharp.Threading.Tasks.Triggers;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;

public class HammerGame : MonoBehaviour
{
    [Header("=== 必须赋值 ===")]
    public GameObject cam3rd;
    public GameObject cam1st;
    public GameObject playerObj;

    [Header("=== UI ===")]
    public Slider barProgress;
    public Text tipText;                 // 下方横排提示文字

    [Header("=== 锤子 Z轴敲打 ===")]
    public float z_Up = 0f;
    public float z_Down = 38f;
    public float moveSpeed = 7f;

    public ParticleSystem Eff;
    // 状态
    private bool isCrafting = false;
    private bool isHitting = false;
    private bool isAllDone = false;

    private void Start()
    {
        // 初始状态
        cam3rd.SetActive(true);
        cam1st.SetActive(false);
        //playerObj.SetActive(true);
        
        // 开局所有UI隐藏
        barProgress.gameObject.SetActive(false);
        tipText.gameObject.SetActive(false);

        barProgress.minValue = 0;
        barProgress.maxValue = 100;
        barProgress.value = 0;
        this.Eff.Stop();
        transform.localRotation = Quaternion.Euler(0, 0, z_Up);
    }
    void Update()
    {
        // 2. 制作完成后按E退出
        if (isCrafting && isAllDone && Input.GetKeyDown(KeyCode.E))
        {
            CloseCraft();
        }
        // 3. 制作中按E敲打
        if (isCrafting && !isAllDone && !isHitting && Input.GetKeyDown(KeyCode.E))
        {
            isHitting = true;
        }
        HammerAnimate();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.tipText.gameObject.SetActive(true);
            this.tipText.text = "按E开始小游戏";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // 1. 未完成且未在制作时，按E进入制作
        if (!isCrafting && !isAllDone && Input.GetKeyDown(KeyCode.E))
        {
            this.tipText.text = "按E锻造";
            OpenCraft();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.tipText.gameObject.SetActive(false);
        }
    }

    void OpenCraft()
    {
        isCrafting = true;
        cam3rd.SetActive(false);
        cam1st.SetActive(true);
        //playerObj.SetActive(false);
        barProgress.gameObject.SetActive(true);
    }

    void CloseCraft()
    {
        isCrafting = false;

        cam3rd.SetActive(true);
        cam1st.SetActive(false);
        //playerObj.SetActive(true);

        // 全部UI关闭
        barProgress.gameObject.SetActive(false);
        tipText.gameObject.SetActive(false);

        // 进度和锤子重置
        barProgress.value = 0;
        transform.localRotation = Quaternion.Euler(0, 0, z_Up);
        UIManager.Instance.ContrlPromote(4);
    }

    void HammerAnimate()
    {
        if (isHitting)
        {
            Quaternion downRot = Quaternion.Euler(0, 0, z_Down);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, downRot, moveSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.localRotation, downRot) < 2f)
            {
                AddProgress();
                this.Eff.Play();
                isHitting = false;
            }
        }
        else
        {
            Quaternion upRot = Quaternion.Euler(0, 0, z_Up);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, upRot, moveSpeed * Time.deltaTime);
        }
    }

    void AddProgress()
    {
        int add = Random.Range(8, 16);
        barProgress.value += add;

        if (barProgress.value >= 100)
        {
            FinishAll();
        }
    }

    void FinishAll()
    {
        isAllDone = true;
        UIManager.Instance.ContrlPromote(4);
        this.tipText.gameObject.SetActive(false);
        // 横排提示文字，放在“燕尾榫制作成功！”下面
        UIManager.Instance.ContrlPromote(7);
        BagManager.Instance.AddBagItem(2);
        BagManager.Instance.AddBagItem(4);
        BagManager.Instance.AddBagItem(5);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class ButtonDetect : MonoBehaviour
{
    [Header("赋值")]
    public GameObject cam3;
    public GameObject player;

    public Transform pourPos;
    public ParticleSystem waterParticle;
    public Slider progressBar;

    [Header("参数")]
    public float mouseSens = 80f;
    public float addSpeed = 4f;

    private float xRot;
    private float yRot;
    private float nowProgress;
    private bool isComplete;

    public ParticleSystem ironParticle;
    public GameObject progressBarObj;  
    void Update()
    {
        LookMouse();
        SyncDir();
        CheckRay();
        ProgressUpdate();

        // 进度满 按E退出
        if (isComplete && Input.GetKeyDown(KeyCode.E))
        {
            ExitPour();
        }
    }

    // 鼠标转动镜头
    void LookMouse()
    {
        float mx = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float my = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        yRot += mx;
        xRot -= my;
        xRot = Mathf.Clamp(xRot, -40f, 40f);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
    }

    // 倾倒方向 = 镜头前方
    void SyncDir()
    {
        if (pourPos != null)
            pourPos.forward = transform.forward;
    }

    // 只检测 PourTarget
    bool CheckRay()
    {
        if (pourPos == null) return false;

        if (Physics.Raycast(pourPos.position, pourPos.forward, out RaycastHit hit, 12f))
        {
            if (hit.collider.CompareTag("PourTarget"))
            {
                return true;
            }
        }
        return false;
    }

    // 慢速涨进度
    void ProgressUpdate()
    {
        if (isComplete) return;

        if (CheckRay())
        {
            nowProgress += addSpeed * Time.deltaTime;
        }

        nowProgress = Mathf.Clamp(nowProgress, 0, 100);
        progressBar.value = nowProgress;

        if (nowProgress >= 100)
        {
            isComplete = true;
        }
    }

    // 进入相机 = 开粒子 + 锁鼠标
    private void OnEnable()
    {
        // 显示粒子
        if (ironParticle != null)
        {
            ironParticle.gameObject.SetActive(true);
            ironParticle.Play();
        }

        // 显示进度条
        if (progressBarObj != null)
            progressBarObj.SetActive(true);  // <-- 加这行

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // 退出
    void ExitPour()
    {
        gameObject.SetActive(false);
        cam3.SetActive(true);
        player.SetActive(true);

        if (waterParticle != null)
            waterParticle.Stop();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        nowProgress = 0;
        isComplete = false;
        progressBar.value = 0;
        // 强制解锁鼠标 兜底修复
        Cursor.lockState = CursorLockMode.None;
    }

    // 场景射线红绿
    private void OnDrawGizmos()
    {
        if (pourPos == null) return;
        Gizmos.color = CheckRay() ? Color.green : Color.red;
        Gizmos.DrawRay(pourPos.position, pourPos.forward * 12f);
    }
    private void OnDisable()
    {
        // 隐藏粒子
        if (ironParticle != null)
        {
            ironParticle.Stop();
            ironParticle.gameObject.SetActive(false);
        }

        // 隐藏进度条
        if (progressBarObj != null)
            progressBarObj.SetActive(false);

        // 强制完全解锁鼠标，修复第三人称不能转视角BUG
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


    }
}
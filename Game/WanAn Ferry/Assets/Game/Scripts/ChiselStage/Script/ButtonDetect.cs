using UnityEngine;
using UnityEngine.UI;

public class ButtonDetect : MonoBehaviour
{
    [Header("赋值")]
    public GameObject cam3;
    public GameObject player;

    public Transform pourPos;
    public ParticleSystem ironParticle;
    public Slider progressBar;

    [Header("参数")]
    public float mouseSens = 80f;
    public float addSpeed = 4f;

    private float xRot;
    private float yRot;
    private float nowProgress;
    private bool isComplete;

    public GameObject progressBarObj;

    void Update()
    {
        LookMouse();
        SyncDir();
        CheckRay();
        ProgressUpdate();

        if (isComplete && Input.GetKeyDown(KeyCode.E))
        {
            ExitPour();
        }
    }

    void LookMouse()
    {
        float mx = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float my = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        yRot += mx;
        xRot -= my;
        xRot = Mathf.Clamp(xRot, -40f, 40f);
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
    }

    void SyncDir()
    {
        if (pourPos != null)
            pourPos.forward = transform.forward;
    }

    bool CheckRay()
    {
        if (pourPos == null) return false;

        if (Physics.Raycast(pourPos.position, pourPos.forward, out RaycastHit hit, 12f))
        {
            return hit.collider.CompareTag("PourTarget");
        }
        return false;
    }

    void ProgressUpdate()
    {
        if (isComplete) return;

        if (CheckRay())
            nowProgress += addSpeed * Time.deltaTime;

        nowProgress = Mathf.Clamp(nowProgress, 0, 100);
        progressBar.value = nowProgress;

        if (nowProgress >= 100)
            isComplete = true;
    }

    void ExitPour()
    {
        // 修复第三人称鼠标BUG
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Input.ResetInputAxes();

        gameObject.SetActive(false);
        cam3.SetActive(true);
        player.SetActive(true);

        nowProgress = 0;
        isComplete = false;
        progressBar.value = 0;
    }

    private void OnEnable()
    {
        if (ironParticle != null)
        {
            ironParticle.gameObject.SetActive(true);
            ironParticle.Play();
        }

        if (progressBarObj != null)
            progressBarObj.SetActive(true);
    }

    private void OnDisable()
    {
        if (ironParticle != null)
        {
            ironParticle.Stop();
            ironParticle.gameObject.SetActive(false);
        }

        if (progressBarObj != null)
            progressBarObj.SetActive(false);
    }
}
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("基础设置")]
    public Transform player;          // 玩家物体
    public float _distance = 5f;      // 固定距离，你设置多少就是多少
    public float mouseSensitivity = 400f; // 鼠标灵敏度

    [Header("视角限制")]
    public float minVerticalAngle = -30f;  // 最低俯视角度
    public float maxVerticalAngle = 60f;   // 最高仰视角度

    // 旋转角度记录
    private float yaw;   // 左右旋转
    private float pitch; // 上下旋转

    void Start()
    {
        // 游戏开始自动锁定鼠标到屏幕中心
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 初始化相机角度
        Vector3 rot = transform.eulerAngles;
        yaw = rot.y;
        pitch = rot.x;
    }

    void LateUpdate()
    {
        // 左Alt切换鼠标锁定/解锁
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                UnityEngine.Cursor.visible = true;
            }
            else
            {
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                UnityEngine.Cursor.visible = false;
            }
        }

        // 只有锁定鼠标时才控制相机
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            // 获取鼠标输入
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // 限制上下视角，防止穿模
            pitch = Mathf.Clamp(pitch, minVerticalAngle, maxVerticalAngle);
        }

        // 计算相机最终位置（核心：距离永远固定）
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 targetPos = player.position - rotation * Vector3.forward * _distance;

        // 应用相机位置和旋转
        transform.rotation = rotation;
        transform.position = targetPos;
    }
}
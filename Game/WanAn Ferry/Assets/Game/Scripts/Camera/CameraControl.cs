using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    private Vector3 dir;
    public float _distance; // 固定距离

    void Start()
    {
        dir = player.position - transform.position;
        _distance = dir.magnitude; // 记录初始长度，永远不变
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked
                ? CursorLockMode.None
                : CursorLockMode.Locked;
        }

        // 左右旋转
        if (Input.GetAxis("Mouse X") != 0)
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.RotateAround(player.position, Vector3.up, mouseX * 400 * Time.deltaTime);
        }

        // 上下旋转
        if (Input.GetAxis("Mouse Y") != 0)
        {
            float mouseY = Input.GetAxis("Mouse Y");
            transform.RotateAround(player.position, transform.right, -mouseY * 400 * Time.deltaTime);
        }

        // 核心修复：方向变，但长度不变！
        dir = player.position - transform.position;
        transform.position = player.position - dir.normalized * _distance;

        transform.LookAt(player);
    }
}
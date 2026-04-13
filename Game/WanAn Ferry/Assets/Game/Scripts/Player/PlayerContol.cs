using UnityEditor.U2D;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerContol : MonoBehaviour
{
    //参数
    [Header("移动速度")]
    public float WalkSpeed = 5f;
    public float RunSpeed = 8f;
    [Header("鼠标灵敏度")]
    public float MouseSensitivity = 2f;
    [Header("视角上下限制")]
    public float MinPitch = -40f;
    public float MaxPitch = 60f;
    [Header("重力")]
    public float Gravity = 20f;
    private float mCameraPitch = 0f;// 相机上下角度x
    //组件
    private CharacterController mCharactContl;
    private Vector3 mVelocity;
    private Transform mMainCam;
    private Animator mAnimator;
    //生命周期
    private void Awake()
    {
        this.mAnimator = GetComponent<Animator>();
        this.mCharactContl = GetComponent<CharacterController>();
        this.mMainCam = Camera.main.transform;
    }
    private void Update()
    {
        this.MoveByGetKey();
        this.LookAt();
        this.ApplyGravity();
    }
    //方法
    private void MoveByGetKey()
    {
        //输入方向
        Vector3 nInputDir = Vector3.zero;
        //接收输入
        if (Input.GetKey(KeyCode.W)) nInputDir.z += 1;
        if (Input.GetKey(KeyCode.S)) nInputDir.z -= 1;
        if (Input.GetKey(KeyCode.A)) nInputDir.x -= 1;
        if (Input.GetKey(KeyCode.D)) nInputDir.x += 1;
        //取模
        if (nInputDir.magnitude > 1) nInputDir.Normalize();
        // 按相机方向转换输入
        Vector3 nCamFwd = mMainCam.forward;
        Vector3 nCamRight = mMainCam.right;
        nCamFwd.y = 0;       nCamRight.y = 0;
        nCamFwd.Normalize(); nCamRight.Normalize();
        //位移方向
        Vector3 nMoveDir = nCamFwd * nInputDir.z + nCamRight * nInputDir.x;
        //奔跑？
        float speed = Input.GetKey(KeyCode.LeftShift) ? this.RunSpeed : this.WalkSpeed;
        this.mAnimator.SetBool("Run", speed == RunSpeed);
        //位移大小
        this.mVelocity.x = nMoveDir.x * speed;
        this.mVelocity.z = nMoveDir.z * speed;
    }
    private void LookAt()
    {
        // 鼠标输入
        float fMouseX = Input.GetAxis("Mouse X") * this.MouseSensitivity;
        float fMouseY = Input.GetAxis("Mouse Y") * this.MouseSensitivity;
        // 1. 玩家左右旋转
        this.transform.Rotate(Vector3.up * fMouseX);
        // 2. 相机上下旋转（只动相机，人物不抬头低头）
        this.mCameraPitch -= fMouseY;
        this.mCameraPitch = Mathf.Clamp(mCameraPitch, MinPitch, MaxPitch);
        // 3. 关键：让相机 完全同步玩家的朝向 + 上下视角
        this.mMainCam.rotation = this.transform.rotation;
        this.mMainCam.Rotate(mCameraPitch, 0, 0);
    }
    private void ApplyGravity()
    {
        if (mCharactContl.isGrounded && mVelocity.y < 0)
        {
            this.mVelocity.y = -2f;
        }
        this.mVelocity.y -= Gravity * Time.deltaTime;
        this.mCharactContl.Move(mVelocity * Time.deltaTime);
    }
}
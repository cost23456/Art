using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    private CharacterController Controller;
    private Animator animator;

    [Header("输入设置")]
    private float horizontal;
    private float vertical;

    [Header("旋转设置")]
    [SerializeField] private float turnSpeed;
    [SerializeField] private Camera mainCamera;

    [Header("跳跃设置")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity = -9.8f;
    private Vector3 velocityGravity;
    private bool IsGround;

    [Header("移动设置")]
    [SerializeField] private float moveSpeed;
    private Vector3 moveDirection;

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetPlayerMove();
        SetPlayerRotation();
        SetPlayerJump();
        SetPlayerGravity();
    }

    private void SetPlayerMove()
    {
        // 用 GetAxisRaw 解决打包后输入平滑导致不切换动画
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;
        cameraForward.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        moveDirection = cameraForward * vertical + cameraRight * horizontal;

        // 关闭根运动，避免动画和代码移动打架
        animator.applyRootMotion = false;

        // 判断是否有移动输入
        float inputMag = new Vector2(horizontal, vertical).magnitude;
        if (inputMag > 0.1f)
        {
            Controller.Move(moveSpeed * Time.deltaTime * moveDirection.normalized);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    private void SetPlayerRotation()
    {
        float inputMag = new Vector2(horizontal, vertical).magnitude;
        if (inputMag > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }

    private void SetPlayerJump()
    {
        if (IsGround && Input.GetButtonDown("Jump"))
        {
            velocityGravity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void SetPlayerGravity()
    {
        velocityGravity.y += gravity * Time.deltaTime;
        Controller.Move(velocityGravity * Time.deltaTime);

        IsGround = Controller.isGrounded;
        if (IsGround && velocityGravity.y < 0)
        {
            velocityGravity.y = -2f;
        }
    }
}
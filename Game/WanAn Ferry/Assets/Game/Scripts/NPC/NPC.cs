
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NPC : MonoBehaviour
{
    // 你只需要拖入 骨盆骨骼 (Hips)
    public Transform hips;
    public float Speed;
    private Vector3 _originalHipsLocalPos;

    private void Start()
    {
        if (hips != null)
        {
           this. _originalHipsLocalPos = hips.localPosition;
        }
    }
    private void LateUpdate()
    {
        // 强制把骨骼拉回原位
        if (hips != null)
        {
            this.hips.localPosition = _originalHipsLocalPos;
        }
        this.transform.Translate(new Vector3(0, 0, Speed*Time.deltaTime));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bounder"))
        {
            this.transform.Rotate(new Vector3(0, 180f,0));
        }
    }
}
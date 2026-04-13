using UnityEngine;

public class MouseManager : MonoBehaviour
{
    //参数
    public float Destance;
    private Ray ray;
    private RaycastHit HitInfo;
    private Color mColor;
    //组件
    public static MouseManager Instance;
    //生命周期
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

    }
    private void Update()
    {
        this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out HitInfo, Destance))
        {
            if (HitInfo.collider.gameObject.CompareTag("TaskItem"))
            {
                Renderer render = HitInfo.collider.GetComponent<Renderer>();
                if (render != null)
                {
                    this.mColor = render.material.color;
                    render.material.color = Color.yellow; // 变黄
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Destroy(HitInfo.collider.gameObject);
                    }
                }
            }
        }
    }
    //方法
    public static MouseManager GetSingleton()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<MouseManager>();
            return Instance;
        }
        return Instance;
    }
    
}

using UnityEngine;
using UnityEngine.EventSystems;

public class Kuai : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Vector3 originalPosition;
    public int x_index;
    public int y_indy;
    private Puzzle pingtu;
    private bool isRight;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        pingtu = FindObjectOfType<Puzzle>();
    }

    public void SetOriginalPos(Vector2 pos)
    {
        originalPosition = pos;
        rectTransform.anchoredPosition = pos;
    }

    public void Initialize(int x, int y)
    {
        x_index = x;
        y_indy = y;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isRight = false;
        Debug.Log("开始拖动！！！");
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsInCorrectPosittion())
        {
            rectTransform.anchoredPosition = pingtu.GetCorrectPosition(x_index, y_indy);
            if (!isRight)
            {
                isRight = true;
                pingtu.OnePieceCorrect();
            }
        }
        else
        {
            rectTransform.anchoredPosition = originalPosition;
            isRight = false;
        }
    }

    private bool IsInCorrectPosittion()
    {
        return Mathf.Abs(rectTransform.anchoredPosition.x - pingtu.GetCorrectPosition(x_index, y_indy).x) < 100f
               && Mathf.Abs(rectTransform.anchoredPosition.y - pingtu.GetCorrectPosition(x_index, y_indy).y) < 100f;
    }
}
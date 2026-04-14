using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Kuai : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    private RectTransform rectTransform;
    private Vector3 originalposition;
    public int x_index;
    public int y_indy;
    private Puzzle pingtu;
    
    void Start()
    {
       
        rectTransform = GetComponent<RectTransform>();
        originalposition = rectTransform.anchoredPosition;
        pingtu = FindObjectOfType<Puzzle>();
    }
    public void Initialize(int x, int y)
    {
        x_index = x;
        y_indy = y;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {

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
            pingtu.JiShu();
            
        }
        else
        {
            rectTransform.anchoredPosition = originalposition;
        }
        
        //rectTransform.anchoredPosition = originalposition;
    }

    private bool IsInCorrectPosittion()
    {
        bool isMath =
            Mathf.Abs(rectTransform.anchoredPosition.x - pingtu.GetCorrectPosition(x_index, y_indy).x) < 100f
            && Mathf.Abs(rectTransform.anchoredPosition.y - pingtu.GetCorrectPosition(x_index, y_indy).y) < 100f;
        return isMath;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

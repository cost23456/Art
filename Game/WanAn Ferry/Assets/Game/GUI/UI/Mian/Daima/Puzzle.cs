using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D Tupian;
    public int row = 4;//行
    public int column = 4;//列
    public GameObject Kuaiss;
    public GameObject PT;
    public Vector3[,] Weiz;
   // public GameObject over;
    
   
  
    void Start()
    {
       // over.SetActive(false);
        Weiz = new Vector3[row, column];
         CreatPuzzle();
        PrintAllCorrectPos();
    }
    private void OnEnable()
    {
       

    }
    void CreatPuzzle()
    {
        int Kuaiwidth = Tupian.width / column;
        int KuaiHeight = Tupian.height / row;
        for (int y = 0; y < row; y++)
        {
            for (int x = 0; x < column; x++)
            {
                Texture2D piece = new Texture2D(Kuaiwidth, KuaiHeight);
                piece.SetPixels(Tupian.GetPixels(x * Kuaiwidth, y * KuaiHeight, Kuaiwidth, KuaiHeight));

                piece.Apply();
                GameObject Kuais = Instantiate(Kuaiss, this.transform);
                Kuais.GetComponent<Image>().sprite = Sprite.Create(piece, new Rect(0, 0, Kuaiwidth, KuaiHeight), new Vector2(0.5f, 0.5f));
                Kuais.GetComponent<Kuai>().Initialize(x, y);
                Kuais.GetComponent<RectTransform>().anchoredPosition =
                        new Vector2(Random.Range(-40f, 840f), Random.Range(-400f, 400f));
                RecordRightPos(x, y);
                // Kuais.GetComponent<RectTransform>().anchoredPosition = Weiz[x, y];

            }
        }
    }
    void RecordRightPos(int x, int y)//正确的位置
    {
        Vector2 anchoredposition = PT.GetComponent<RectTransform>().anchoredPosition;
        Vector2 TP = new Vector2(anchoredposition.x - 300, anchoredposition.y - 300);
        Weiz[x, y] = new Vector3(TP.x + x * 200, TP.y + y * 200, 0);

    }
    void PrintAllCorrectPos()
    {
        for (int y = 0; y < row; y++)
        {
            for (int x = 0; x < column; x++)
            {
                Debug.Log("拼图块 (" + x + "," + y + ") 的正确位置 = " + Weiz[x, y]);
            }
        }
    }

    public Vector3 GetCorrectPosition(int x, int y)
    {
        return Weiz[x, y];
    }
    //public void JiShu()
    //{
    //    if (a) return;
    //    b++;
    //    if (b == 16)
    //    {
    //        over.SetActive(true);
    //        a = true;
    //        over.transform.SetAsLastSibling();
    //    }
    //}
    private void Update()
    {
        
    }
}

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Puzzle : MonoBehaviour
{
    public Texture2D Tupian;
    public GameObject Kuaiss;
    public CanvasGroup mCanvas;
    private Sequence mDO;
    public Vector3[,] Weiz;

    private int row = 3;
    private int column = 3;
    private float uiWidth = 1005f;
    private float uiHeight = 709f;
    private int correctCount = 0;

    private void Awake()
    {
        mCanvas = GetComponent<CanvasGroup>();
        mCanvas.blocksRaycasts = true; // 必须开！
        mCanvas.interactable = true;
    }

    private void OnEnable()
    {
        correctCount = 0;
    }
    private void Start()
    {
        Weiz = new Vector3[row, column];
        CreatPuzzle();
    }

    void CreatPuzzle()
    {
        float pieceW = uiWidth / column;
        float pieceH = uiHeight / row;
        float texW = Tupian.width;
        float texH = Tupian.height;

        for (int y = 0; y < row; y++)
        {
            for (int x = 0; x < column; x++)
            {
                Rect rect = new Rect(
                    x * pieceW / uiWidth * texW,
                    y * pieceH / uiHeight * texH,
                    pieceW / uiWidth * texW,
                    pieceH / uiHeight * texH
                );

                Sprite sprite = Sprite.Create(Tupian, rect, new Vector2(0.5f, 0.5f));
                GameObject kuai = Instantiate(Kuaiss, transform);

                Image img = kuai.GetComponent<Image>();
                img.sprite = sprite;
                img.rectTransform.sizeDelta = new Vector2(pieceW, pieceH);
                img.raycastTarget = true; // 强制开启射线

                Kuai k = kuai.GetComponent<Kuai>();
                k.Initialize(x, y);

                Vector2 randomPos = new Vector2(Random.Range(-40f, 840f), Random.Range(-400f, 400f));
                k.SetOriginalPos(randomPos);

                RecordRightPos(x, y);
            }
        }
    }

    void RecordRightPos(int x, int y)
    {
        float pieceW = 1005f / 3f;
        float pieceH = 709f / 3f;
        Weiz[x, y] = new Vector3((x - 1) * pieceW, (y - 1) * pieceH, 0);
    }

    public Vector3 GetCorrectPosition(int x, int y) => Weiz[x, y];

    public void OnePieceCorrect()
    {
        correctCount++;
        CheckIfAllCorrect();
    }

    private void CheckIfAllCorrect()
    {
        if (correctCount >= 9)
        {
            ContrlPuzzle(0);
            Destroy(gameObject, 1.4f);
            TaskManager.Instance.SetFinishTask(4);
            UIManager.Instance.ContrlPromote(5);
        }
    }

    public void ContrlPuzzle(int target)
    {
        DOTween.Kill(mCanvas);
        mCanvas.DOFade(target, 1f);
    }
}
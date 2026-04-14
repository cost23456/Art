using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PuzzleTang : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        if (text == null)
            text = GetComponent<Text>();

        if (text == null) return;

        // 2. 先把旧动画杀掉（防止报错）
        text.DOKill();

        // 3. 先显示文字，不让它消失
        //text.text = "恭喜你挑战成功";

        // 4. 如果你想要打字动画，用这个
        text.DOText("恭喜你挑战成功", 2f);
    }
}
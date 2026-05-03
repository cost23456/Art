using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void QuitGame()
    {
        // 打包后的退出
        Application.Quit();

        // 只有编辑器环境才会编译下面这段
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
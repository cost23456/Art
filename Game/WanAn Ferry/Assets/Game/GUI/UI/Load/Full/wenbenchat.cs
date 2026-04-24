using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class wenbenchat : MonoBehaviour
{
    public NPC_1 npc;
    public TextAsset textAsset;
    public Text nameText; // 改名避免和关键字冲突
    public Text duihua;
    private List<string> dialogueList = new List<string>();
    int n = 0;
   

    void Start()
    {
        // 初始化对话列表
        GetEachLineContent(textAsset);
        // 先加载身份标识（A/B），再显示第一条对话
        if (dialogueList.Count > 0)
        {
            ChangeFace(); // 先设置初始头像和名字
            // 确保还有对话内容可显示
            if (n < dialogueList.Count)
            {
                duihua.text = dialogueList[n];
                n++;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 检查是否对话已结束
            if (n >= dialogueList.Count)
            {
                gameObject.SetActive(false);
                n = 0; // 重置索引，方便下次使用
                Start();
                return;
            }

            // 检查当前行是否是身份标识（A/B）
            if (dialogueList[n] == "A" || dialogueList[n] == "B")
            {
                ChangeFace(); // 切换头像和名字，内部会n++
                // 切换身份后，显示对应的对话内容
                if (n < dialogueList.Count)
                {
                    duihua.text = dialogueList[n];
                    n++;
                }
            }
            else
            {
                // 直接显示对话内容
                duihua.text = dialogueList[n];
                n++;
            }
        }
    }

    // 读取文本文件的每一行，过滤空行
    private void GetEachLineContent(TextAsset textAsset)
    {
        dialogueList.Clear();
        n = 0;
        if (textAsset == null)
        {
            Debug.LogError("文本文件未赋值！");
            return;
        }

        // 按换行分割，同时处理Windows(\r\n)和Linux(\n)的换行符
        string[] chatContent = textAsset.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        foreach (var eachLine in chatContent)
        {
            // 过滤空行和纯空格的行
            string line = eachLine.Trim();
            if (!string.IsNullOrEmpty(line))
            {
                dialogueList.Add(line);
            }
        }
    }

    // 切换头像和名字
    void ChangeFace()
    {
        if (n >= dialogueList.Count) return; // 防止越界

        switch (dialogueList[n])
        {
            case "A":
                
                nameText.text = "名字1";
                Debug.Log("切换为角色A"); // 调试用
                n++;
                break;
            case "B":
                
                nameText.text = "名字2";
                Debug.Log("切换为角色B"); // 调试用
                n++;
                break;
            default:
                // 如果不是A/B，不做处理
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class wenbenchat : MonoBehaviour
{
    //参数
    public  int mAudioClipIndex = 0;
    public  int mDialogIndex = 0;
    public bool isDialogCompleted = false;
    //组件
    public List<TextAsset> textAsset;
    public Text nameText; // 改名避免和关键字冲突
    public Text duihua;
    private List<string> dialogueList = new List<string>();
    private List<AudioClip> audioClips = new List<AudioClip>();
    private AudioSource mAudioSource;
    //生命周期
    private void Awake()
    {
        this.mAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // 检查是否对话已结束
            if (mDialogIndex >= dialogueList.Count)
            {
                this.gameObject.SetActive(false);
                this.mDialogIndex = 0; // 重置索引，方便下次使用
                this.isDialogCompleted = true;
                return;
            }
            // 检查当前行是否是身份标识（A/B）
            if (dialogueList[mDialogIndex] == "A：" || dialogueList[mDialogIndex] == "B：")
            {
                ChangeFace(); // 切换头像和名字，内部会n++
                // 切换身份后，显示对应的对话内容
                if (mDialogIndex < dialogueList.Count)
                {
                    duihua.text = dialogueList[mDialogIndex];
                    mDialogIndex++;
                }
            }
            else
            {
                // 直接显示对话内容
                this.duihua.text = dialogueList[mDialogIndex];
                this.mDialogIndex++;
            }
        }
    }
    //方法
    public void Init(int aIndex)
    {
        // 初始化对话列表
        GetEachLineContent(textAsset[aIndex]);
        // 先加载身份标识（A/B），再显示第一条对话
        if (dialogueList.Count > 0)
        {
            ChangeFace(); // 先设置初始头像和名字
            // 确保还有对话内容可显示
            if (mDialogIndex < dialogueList.Count)
            {
                this.duihua.text = dialogueList[mDialogIndex];
                this.mDialogIndex++;
            }
        }
    }
    // 读取文本文件的每一行，过滤空行
    private void GetEachLineContent(TextAsset textAsset)
    {
        this.dialogueList.Clear();
        this.mDialogIndex = 0;
        this.isDialogCompleted = false;
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
        if (mDialogIndex >= dialogueList.Count) return; // 防止越界
        switch (dialogueList[mDialogIndex])
        {
            case "A：":
                this.nameText.text = "名字1";
                Debug.Log("切换为角色A"); // 调试用
                this.mDialogIndex++;
                break;
            case "B：":
                this.nameText.text = "名字2";
                Debug.Log("切换为角色B"); // 调试用
                this.mDialogIndex++;
                this.ChangeAudioIndex();
                break;
            default:
                // 如果不是A/B，不做处理
                break;
        }
    }
    public void GetAudioFormNPC(List<AudioClip> clips)
    {
        this.audioClips = clips;
        Debug.Log("FinshTaskAudio"+ audioClips );
    }
    public void ChangeAudioIndex()
    {
        if (mAudioClipIndex < audioClips.Count)
        {
            this.mAudioSource.clip = audioClips[mAudioClipIndex];
            this.mAudioClipIndex++;
            this.mAudioSource.Play();
        }
        else
        {
            this.mAudioClipIndex = 0;
        }
    }
}

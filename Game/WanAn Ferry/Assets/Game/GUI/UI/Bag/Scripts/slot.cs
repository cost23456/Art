using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int slotID;//空格ID 等于物品ID
    public ItemData slotItem;
    public Image slotImage;
    public Text slotNum;
    public GameObject itemInSlot;
    public string slotInfo;
    private bool isPointerOver = false; // 标记鼠标是否悬停在该位置
    private float hoverTime = 0; // 记录鼠标已悬停的时间
    private const float hoverThreshold = 1.0f; // 鼠标悬停时间阈值：1秒
    /*public void ItemOnClicked()
    {
        BagManager.UpdateItemInfo(slotInfo);
    }*/
    void Update()
    {
        // 如果鼠标正悬停在这个slot上
        if (isPointerOver)
        {
            hoverTime += Time.deltaTime;

            // 如果悬停时间超过阈值，就调用 UpdateItemInfo，然后重置状态
            if (hoverTime >= hoverThreshold)
            {
                BagManager.UpdateItemInfo(slotInfo);
                hoverTime = 0; // 重置计时器
                isPointerOver = false; // 防止重复调用
            }
        }
    }

    public void SetupSlot(ItemData item)
    {
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }
        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;
    }

    // 当鼠标指针进入该UI元素时触发
    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true; // 开启悬停状态
        hoverTime = 0; // 重置计时器
    }

    // 当鼠标指针离开该UI元素时触发
    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false; // 关闭悬停状态
        hoverTime = 0; // 重置计时器
    }


}

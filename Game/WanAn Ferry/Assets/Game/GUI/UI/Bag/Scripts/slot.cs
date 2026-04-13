using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    public int slotID;//空格ID 等于物品ID
    public ItemData slotItem;
    public Image slotImage;
    public Text slotNum;
    public GameObject itemInSlot;
    public string slotInfo;
    public void ItemOnClicked()
    {
        BagManager.UpdateItemInfo(slotInfo);
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
}

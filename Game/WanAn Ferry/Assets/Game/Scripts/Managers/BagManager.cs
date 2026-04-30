using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : Singleton<BagManager>
{
    public List<ItemData> ItemDatas;
    public BagMain Bag;
    //获取ItemData
    public ItemData GetItemData(string ItemDesc)
    {
        foreach (ItemData itemData in ItemDatas)
        {
            if (itemData.itemInfo == ItemDesc)
            {
                return itemData;
                break;
            }
        }
        Debug.Log("找不到对应的物体");
        return null;
    }
    public ItemData GetItemData(int Item_ID)
    {
        foreach (ItemData itemData in ItemDatas)
        {
            if (itemData.Item_ID == Item_ID)
            {
                return itemData;
                break;
            }
        }
        Debug.Log("找不到对应的物体");
        return null;
    }
    //增加背包物品
    public void AddBagItem(int Item_ID)
    {
        this.Bag.myBag.itemList.Add(GetItemData(Item_ID));
        this.Bag.RefreshAllItem();
    }
}

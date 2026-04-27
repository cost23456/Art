using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class slot : MonoBehaviour
{
    public Image ItemIcon;
    public Text ItemDesc;

    //Ë¢ÐÂItem
    public void RefeshItem(ItemData itemData)
    {
        this.ItemIcon.sprite = itemData.itemImage;
        this.ItemDesc.text = itemData.itemInfo.ToString();
    }
}

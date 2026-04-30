using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Props/New Item")]
public class ItemData : ScriptableObject
{
    public int Item_ID;
    public Sprite itemImage;
    [TextArea]
    public string itemInfo;
}

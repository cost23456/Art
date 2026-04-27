using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Bag", menuName = "Props/New Bag")]
public class BagData : ScriptableObject
{
    public List<ItemData> itemList = new List<ItemData>();
    
}

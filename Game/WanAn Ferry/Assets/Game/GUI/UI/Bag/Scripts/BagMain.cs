using System.Collections;

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BagMain : MonoBehaviour
{
    public BagData myBag;
    public GameObject slotGrid;
    public GameObject emtySlot;
    public List<GameObject> slots = new List<GameObject>();
    public AudioClip OpenFX;

    private void Start()
    {
        this.RefreshGird();
    }
    //方法
    public void RefreshGird()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject slot  =  Instantiate(emtySlot);
            slot.transform.SetParent(slotGrid.transform);
            this.slots.Add(slot);
        }
        this.RefreshAllItem();
    }
    public void RefreshAllItem()
    {
        this.RefreshSlotsList();
        for (int i = 0; i < 9; i++) 
        {
            if (i < this.myBag.itemList.Count)
            {
                this.slots[i].GetComponent<slot>().RefeshItem(this.myBag.itemList[i]);
            }
        }
    }
    public void RefreshSlotsList()
    {
        for (int i = 0; i < this.myBag.itemList.Count; i++)
        {
            if (i < this.myBag.itemList.Count)
            {
                this.slots[i].GetComponent<slot>().RefeshItem(this.myBag.itemList[i]);
            }
        }
    }
    public void PlayAudio()
    {
        AudioManager.Instance.PlayFXAudio(OpenFX);
    }
}
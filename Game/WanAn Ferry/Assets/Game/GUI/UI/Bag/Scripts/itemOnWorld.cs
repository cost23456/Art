using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{
    public ItemData thisitem;
    public BagData playerBag;
    public GameObject pickUpHint; // UI提示框（例如提示UI）

    private bool playerInRange = false; // 记录玩家是否在范围内

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true; // 玩家进入范围
            ShowPickUpHint(true); // 显示提示
        }
    }

    // 当玩家离开碰撞范围
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false; // 玩家离开范围
            ShowPickUpHint(false); // 隐藏提示
        }
    }

    private void Update()
    {
        // 如果玩家在范围内并按下F键
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            AddNewItem(); // 添加物品到背包
            ShowPickUpHint(false); // 隐藏提示
            Destroy(gameObject); //销毁物品对象
        }
    }

    public void AddNewItem()
    {
        if (!playerBag.itemList.Contains(thisitem))
        {
            //playerBag.itemList.Add(thisitem);
            //BagManage1.CreateNewItem(thisitem);
            //thisitem.itemHeld = 1;
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i] == null)
                {
                    playerBag.itemList[i] = thisitem;
                    break;
                }
            }
        }
        else
        {
            thisitem.itemHeld++;
        }
        BagManager.RefreshItem();
    }
    private void ShowPickUpHint(bool state)
    {
        if (pickUpHint != null)
        {
            pickUpHint.SetActive(state);
        }
    }
}
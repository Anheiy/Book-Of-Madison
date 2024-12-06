using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Item[] items = new Item[3];
    public Image[] imageSlots;
    public GameObject playerHands;
    private void Update()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            RotateInventoryBackwards();
        }
        else if(Input.mouseScrollDelta.y < 0)
        {
            RotateInventoryForwards();
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            DropItem();
        }
    }
    public void AddItem(Item item, GameObject reference)
    {
        bool canAdd = false;
        int slot = 0;

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                canAdd = true;
                slot = i;
                break;
            }
        }
        if (canAdd)
        {
            items[slot] = item;
            Destroy(reference);
            Debug.Log("Item added");
        }
        else
        {
            Debug.Log("Item cannot be added");
        }
        UpdateInventory();
    }
    public void RemoveItem(int slot)
    {
        items[slot] = null;
        UpdateInventory();
    }
    public void UpdateInventory()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i] != null)
            imageSlots[i].sprite = items[i].itemSprite;
            else
            {
                imageSlots[i].sprite = null;
            }
        }
        ShowObject();
    }
    public void RotateInventoryForwards()
    {
        Item lastItem = items[0];
        for (int i = 0; i < imageSlots.Length - 1; i++)
        {
            items[i] = items[i + 1];
        }
        items[items.Length - 1] = lastItem;
        UpdateInventory();
    }
    public void RotateInventoryBackwards()
    {
        Item lastItem = items[items.Length - 1];
        for (int i = imageSlots.Length - 1; i > 0; i--)
        {
                items[i] = items[i - 1];
        }
        items[0] = lastItem;
        UpdateInventory();
    }
    public void ShowObject()
    {
        for(int i = 0; i < playerHands.transform.childCount; i++)
        {
            Destroy(playerHands.transform.GetChild(0).gameObject);
        }
        if (items[0] != null)
        {
            GameObject Object = Instantiate(items[0].ObjectPrefab);
            Object.transform.rotation = playerHands.transform.rotation;
            Object.transform.position = playerHands.transform.position;
            Object.transform.SetParent(playerHands.transform, true);
            Object.GetComponent<Collider>().isTrigger = true;
            Destroy(Object.GetComponent<Rigidbody>());
            Destroy(Object.GetComponent<ItemHolder>());
        }
    }
    public void DropItem()
    {
        if (items[0] != null)
        {
            GameObject Object = Instantiate(items[0].ObjectPrefab);
            Object.transform.position = playerHands.transform.position;
            items[0] = null;
            UpdateInventory();
        }
    }

}

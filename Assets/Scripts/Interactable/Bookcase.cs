using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookcase : UIDisplay
{
    public Item key;
    InventoryManager inventory;

    private void Start()
    {
        inventory = GameObject.Find("GameManager").GetComponent<InventoryManager>();
    }
    public void SpecialBookSelected(GameObject obj)
    {
        inventory.AddItem(key, null);
        Destroy(obj);
    }
}

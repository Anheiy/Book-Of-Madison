using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : Interactable
{
    public Item item;
    InventoryManager inventoryManager;
    public List<OptionPrompt> prompt;
    private void Start()
    {
        inventoryManager = GameObject.Find("GameManager").GetComponent<InventoryManager>();
    }
    public override void Interact()
    {
        inventoryManager.AddItem(item, this.gameObject);
    }

    public override List<OptionPrompt> ScrollText()
    {
        return prompt;
    }
}

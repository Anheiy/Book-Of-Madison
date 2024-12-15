using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Item[] items = new Item[3];
    public Image[] imageSlots;
    public GameObject meleeWeaponLocation;
    public GameObject rangedWeaponLocation;
    public bool isScrollLocked = false;

    private GameObject Body;
    private Animator animator;
    private GameStateManager gameStateManager;
    
    
    private void Start()
    {
        Body = GameObject.Find("PlayerBody");
        animator = Body.GetComponent<Animator>();
        gameStateManager = GetComponent<GameStateManager>();   
    }
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            UseItem();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ScopeItem();
        }
        else if( Input.GetKeyUp(KeyCode.Mouse1))
        {
            UnscopeItem();
        }
    }
    public void ScopeItem()
    {
        Debug.Log("scoping");
        if (items[0] is RangedWeapon)
        {
            animator.SetBool("isScoping",true);
        }
    }
    public void UnscopeItem()
    {
        Debug.Log("scoping");
        if (items[0] is RangedWeapon)
        {
            animator.SetBool("isScoping", false);
        }
    }
    public void UseItem()
    {
        if (items[0] != null)
        {
            switch(items[0])
            {
                case MeleeWeapon:
                    animator.SetTrigger("isAttacking");
                    break;
                case RangedWeapon:
                    Debug.Log("Firing");
                    if(animator.GetBool("isFiring") == false)
                    animator.SetBool("isFiring", true);
                    break;
                case Consumable:
                    break;
                case Key:
                    break;
            }
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
        if (gameStateManager.GetState() == "play")
        {
            Item lastItem = items[0];
            for (int i = 0; i < imageSlots.Length - 1; i++)
            {
                items[i] = items[i + 1];
            }
            items[items.Length - 1] = lastItem;
            UpdateInventory();
        }
    }
    public void RotateInventoryBackwards()
    {
        if (gameStateManager.GetState() == "play")
        {
            Item lastItem = items[items.Length - 1];
            for (int i = imageSlots.Length - 1; i > 0; i--)
            {
                items[i] = items[i - 1];
            }
            items[0] = lastItem;
            UpdateInventory();
        }
    }
    public void ShowObject()
    { 
        for (int i = 0; i < rangedWeaponLocation.transform.childCount; i++)
            {
                Destroy(rangedWeaponLocation.transform.GetChild(0).gameObject);
            }
        for (int i = 0; i < meleeWeaponLocation.transform.childCount; i++)
            {
                Destroy(meleeWeaponLocation.transform.GetChild(0).gameObject);
            }
        if (items[0] is MeleeWeapon)
        {

            if (items[0] != null)
            {
                // Instantiate the object at the rangedWeaponLocation's world position and rotation
                GameObject Object = Instantiate(
                    items[0].HeldPrefab,
                    meleeWeaponLocation.transform.position,
                    meleeWeaponLocation.transform.rotation
                );

                // Set it as a child while preserving world position
                Object.transform.SetParent(meleeWeaponLocation.transform, true);

                // Reset the local transform
                Object.transform.localPosition = Vector3.zero;
                Object.transform.localRotation = Quaternion.identity;

                // Adjustments to the instantiated object
                Object.GetComponent<Collider>().isTrigger = true;
                Destroy(Object.GetComponent<Rigidbody>());
                Destroy(Object.GetComponent<ItemHolder>());
            }
        }
        else if (items[0] is RangedWeapon)
        {

            if (items[0] != null)
            {
                // Instantiate the object at the rangedWeaponLocation's world position and rotation
                GameObject Object = Instantiate(
                    items[0].HeldPrefab,
                    rangedWeaponLocation.transform.position,
                    rangedWeaponLocation.transform.rotation
                );

                // Set it as a child while preserving world position
                Object.transform.SetParent(rangedWeaponLocation.transform, true);

                // Reset the local transform
                Object.transform.localPosition = Vector3.zero;
                Object.transform.localRotation = Quaternion.identity;
                Object.transform.localScale = new Vector3(3,3,3);

                // Adjustments to the instantiated object
                Object.GetComponent<Collider>().isTrigger = true;
                Destroy(Object.GetComponent<Rigidbody>());
                Destroy(Object.GetComponent<ItemHolder>());
            }

        }
    }
    public void DropItem()
    {
        if (items[0] != null)
        {
            GameObject Object = Instantiate(items[0].WorldPrefab);
            Object.transform.position = meleeWeaponLocation.transform.position;
            items[0] = null;
            UpdateInventory();
        }
    }

}

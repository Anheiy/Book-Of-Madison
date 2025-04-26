using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consume : MonoBehaviour
{
    Health health;
    InventoryManager inventoryManager;

    private void Start()
    {
        health = GameObject.Find("Player").GetComponent<Health>();
        inventoryManager = GameObject.Find("GameManager").GetComponent<InventoryManager>();
    }
    public void EffectPlayer()
    {
        health.IncreaseHealth(((Consumable)inventoryManager.GetCurrentItem()).HealAmount);
        health.ReduceHealth(((Consumable)inventoryManager.GetCurrentItem()).DamageAmount);
        inventoryManager.DeleteCurrentItem();   
    }
}

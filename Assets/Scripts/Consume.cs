using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consume : MonoBehaviour
{
    Health health;
    InventoryManager inventoryManager;
    public AudioClip eatClip;

    private void Start()
    {
        health = GameObject.Find("Player").GetComponent<Health>();
        inventoryManager = GameObject.Find("GameManager").GetComponent<InventoryManager>();
    }
    public void StartConsume()
    {
        SFXManager.Instance.PlaySFX(eatClip, 0.2f);
    }
    public void EffectPlayer()
    {
        Debug.Log("Consuming, Amount: " + (((Consumable)inventoryManager.GetCurrentItem()).HealAmount - ((Consumable)inventoryManager.GetCurrentItem()).DamageAmount));
        health.IncreaseHealth(((Consumable)inventoryManager.GetCurrentItem()).HealAmount);
        health.ReduceHealth(((Consumable)inventoryManager.GetCurrentItem()).DamageAmount);
        inventoryManager.DeleteCurrentItem();   
    }
}

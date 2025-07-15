using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public int health;
    public int maxHealth = 1;
    public bool isInvulnerable;
    private Coroutine damageDance;
    public delegate void onDamaged();
    public onDamaged ondamaged;
    public delegate void onHealed();
    public onDamaged onhealed;
    //
    public UnityEvent damaged;
    public UnityEvent dying;
    private AudioClip destroySFX;

    private void Start()
    {
        health = maxHealth;
        destroySFX = Resources.Load<AudioClip>("break");
    }
    public void ReduceHealth(int amount, bool breakInvulnerable = false)
    {
        if (isInvulnerable && !breakInvulnerable)
            return;
        if(amount == 0)
            return; 
        health = health - amount;
        damageDance = StartCoroutine(DamageDance());
        ondamaged?.Invoke();
        damaged?.Invoke();
        if(health <= 0)
        {
            dying?.Invoke();
            Destroy(gameObject);
            SFXManager.Instance.PlaySFX(destroySFX, volume: 0.1f);
        }
    }
    public void IncreaseHealth(int amount)
    {
        if (health < maxHealth)
        {
            Debug.Log($"health: {health}, amount added: {amount}");
            health = health + amount;
            onhealed?.Invoke();
        }
    }

    IEnumerator DamageDance()
    {
        yield return transform.DOShakePosition(0.05f);
    }
}

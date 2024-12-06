using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int health;
    public int maxHealth = 1;
    private Coroutine damageDance;
    public delegate void onDamaged();
    public onDamaged ondamaged;
    private void Start()
    {
        health = maxHealth;
    }
    public void ReduceHealth(int amount)
    {
        health = health - amount;
        damageDance = StartCoroutine(DamageDance());
        ondamaged?.Invoke();
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DamageDance()
    {
        yield return transform.DOShakePosition(0.2f);
    }
}

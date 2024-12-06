using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Damageable
{
    public List<GameObject> healthList = new List<GameObject>();
    void Awake()
    {
        ondamaged += ReduceHealthStats;
    }

    public void ReduceHealthStats()
    {
        for (int i = health; i < maxHealth; i++)
        {
            healthList[i].SetActive(false);
        }
    }
}

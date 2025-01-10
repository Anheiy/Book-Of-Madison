using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Damageable
{
    public List<GameObject> healthList = new List<GameObject>();
    void Awake()
    {
        ondamaged += ReduceHealthStats;
        onhealed += IncreaseHealthStats;
    }

    public void ReduceHealthStats()
    {
        for (int i = health; i < maxHealth; i++)
        {
            healthList[i].SetActive(false);
        }
    }
    public void IncreaseHealthStats()
    {
        for (int i = health - 1; i < maxHealth; i++)
        {
            healthList[i].SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Health : Damageable
{
    private List<GameObject> healthList = new List<GameObject>();
    void Awake()
    {
        ondamaged += ReduceHealthStats;
        onhealed += IncreaseHealthStats;
        InvokeRepeating("Cycle", 0, 5);
        Transform heartsParent = GameObject.Find("Hearts").transform;
        foreach (Transform child in heartsParent)
        {
            healthList.Add(child.gameObject);
        }
    }
    private void OnDestroy()
    {
        ondamaged -= ReduceHealthStats;
        onhealed -= IncreaseHealthStats;
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
        for (int i = 0; i < health; i++)
        {
            healthList[i].SetActive(true);
        }
    }

    public void Cycle()
    {
        StartCoroutine(heartPump());
    }
    IEnumerator heartPump()
    {
        for (int i = 0; i < healthList.Count; i++)
        {
            int index = i;
            
            healthList[index].transform.DOScale(1.25f, 0.5f).OnComplete(() => healthList[index].transform.DOScale(1, 0.5f));
            yield return new WaitForSeconds(1.5f);
        }
    }
}

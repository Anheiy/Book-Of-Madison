using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnPrefab;
    [SerializeField] private Vector3[] spawnLocations;

    public void SpawnEnemies()
    {
        if (SpawnPrefab == null)
            return;
        for (int i = 0; i < SpawnPrefab.Length; i++)
        {
            GameObject enemy = Instantiate(SpawnPrefab[i]);
            enemy.transform.position = spawnLocations[i];
        }
        SpawnPrefab = null;
    }
}

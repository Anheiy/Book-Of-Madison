using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public Item spawnedItem;
    public void SpawnItem()
    {
        Instantiate(spawnedItem.Prefab, transform.position, Quaternion.identity);;
    }
}

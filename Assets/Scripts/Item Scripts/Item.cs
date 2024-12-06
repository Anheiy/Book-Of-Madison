using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject 
{
    public string itemName = "Placeholder Name";
    public string itemDescription = "Placeholder Text";
    public Sprite itemSprite;
    public GameObject ObjectPrefab;
    public bool isWeapon = false;
    public int WeaponDamage = 0;
    public int Weight = 1;
}

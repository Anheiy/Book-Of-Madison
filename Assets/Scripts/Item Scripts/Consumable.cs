using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Consumable Item")]
public class Consumable : Item
{
    public int HealAmount = 0;
    public int DamageAmount = 0;
}

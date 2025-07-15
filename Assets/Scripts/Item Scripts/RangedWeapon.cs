using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Create Ranged Weapon")]
public class RangedWeapon : Weapon
{
    public float ShotSpeed = 0.3f;
    public GameObject projectile;
    public AudioClip shotSFX;
}

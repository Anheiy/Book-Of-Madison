using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public void StartSwing()
    {
        GameObject.Find("WeaponLocation").transform.GetChild(0).GetChild(0).GetComponent<DamageOnHit>().canDamage = true;
    }
    public void EndSwing()
    {
        GameObject.Find("WeaponLocation").transform.GetChild(0).GetChild(0).GetComponent<DamageOnHit>().canDamage = false;
        GameObject.Find("WeaponLocation").transform.GetChild(0).GetChild(0).GetComponent<DamageOnHit>().thingsHit.Clear();
    }
}

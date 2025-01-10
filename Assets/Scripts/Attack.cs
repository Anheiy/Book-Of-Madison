using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public void StartSwing()
    {
        GameObject.Find("MeleeLocation").transform.GetChild(0).GetComponent<DamageOnHit>().canDamage = true;
    }
    public void EndSwing()
    {
        GameObject.Find("MeleeLocation").transform.GetChild(0).GetComponent<DamageOnHit>().canDamage = false;
        GameObject.Find("MeleeLocation").transform.GetChild(0).GetComponent<DamageOnHit>().thingsHit.Clear();
    }
}

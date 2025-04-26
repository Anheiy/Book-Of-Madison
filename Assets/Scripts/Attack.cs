using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void StartSwing()
    {
        animator.SetFloat("SwingSpeed", ((MeleeWeapon)InventoryManager.items[0]).SwingSpeed);
        GameObject.Find("MeleeLocation").transform.GetChild(0).GetComponent<DamageOnHit>().canDamage = true;
    }
    public void EndSwing()
    {
        GameObject.Find("MeleeLocation").transform.GetChild(0).GetComponent<DamageOnHit>().canDamage = false;
        GameObject.Find("MeleeLocation").transform.GetChild(0).GetComponent<DamageOnHit>().thingsHit.Clear();
    }
}

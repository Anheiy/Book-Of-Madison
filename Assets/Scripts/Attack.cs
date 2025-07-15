using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
    public AudioClip swingclip;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void StartSwing()
    {
        SFXManager.Instance.PlaySFX(swingclip, 0.1f);
        animator.SetFloat("SwingSpeed", ((MeleeWeapon)InventoryManager.items[0]).SwingSpeed);
        GameObject.Find("MeleeLocation").transform.GetChild(0).GetComponent<DamageOnHit>().canDamage = true;
    }
    public void EndSwing()
    {
        GameObject.Find("MeleeLocation").transform.GetChild(0).GetComponent<DamageOnHit>().canDamage = false;
        GameObject.Find("MeleeLocation").transform.GetChild(0).GetComponent<DamageOnHit>().thingsHit.Clear();
    }
}

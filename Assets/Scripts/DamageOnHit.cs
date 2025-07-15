using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public bool canDamage;
    public bool destroyOnCollide = false;
    public int destroyOnCollideDamage = 5;
    public ItemHolder itemHolder;
    public List<GameObject> thingsHit;

    private void Start()
    {
        itemHolder = GetComponent<ItemHolder>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Hit something: " + collision.name);
        if (canDamage)
        {
            if (!destroyOnCollide)
            {
                if (collision.gameObject.GetComponent<Damageable>() != null && !thingsHit.Contains(collision.gameObject) && collision.tag != "Player")
                {
                    collision.gameObject.GetComponent<Damageable>().ReduceHealth(((MeleeWeapon)itemHolder.item).DamageOnHit);
                    if(((MeleeWeapon)itemHolder.item).attackSFX != null)
                    SFXManager.Instance.PlaySFX(((MeleeWeapon)itemHolder.item).attackSFX, volume: 0.1f, pitch: 0.5f);
                    thingsHit.Add(collision.gameObject);
                }
            }
            else
            {
                if (collision.gameObject.GetComponent<Damageable>() != null && !thingsHit.Contains(collision.gameObject) && collision.tag != "Player")
                {
                    collision.gameObject.GetComponent<Damageable>().ReduceHealth(destroyOnCollideDamage, true);
                    thingsHit.Add(collision.gameObject);
                    Destroy(gameObject);
                }
            }
        }

    }
}

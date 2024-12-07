using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public bool canDamage;
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
            if (collision.gameObject.GetComponent<Damageable>() != null && !thingsHit.Contains(collision.gameObject) && collision.tag != "Player")
            {
                collision.gameObject.GetComponent<Damageable>().ReduceHealth(((MeleeWeapon)itemHolder.item).DamageOnHit);
                thingsHit.Add(collision.gameObject);
            }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    private float timer = 0;
    private float timePerAttack = 1;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Entered");
        if (other.tag == "Player")
        {
            if (timer <= 0)
            {
                Debug.Log("Entered 2");
                other.transform.parent.GetComponent<Damageable>().ReduceHealth(1);
                timer = timePerAttack;
            }
        }
    }
    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}

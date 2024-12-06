using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float timerPerHit = 1f;
    public float timer = 0;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" && timer == 0)
        {
            timer = 0.4f;
            collision.gameObject.GetComponent<Damageable>().ReduceHealth(1);
        }
        else if (collision.gameObject.tag != "Player" && collision.gameObject.GetComponent<Damageable>() != null)
        {
            collision.gameObject.GetComponent<Damageable>().ReduceHealth(1);
        }
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
        }
    }
}

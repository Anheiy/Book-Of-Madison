using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhilAddons : MonoBehaviour
{
    public float summonTimer = 0;
    public GameObject rat;
    public GameObject plagued;
    public GameObject damage_item;
    public Damageable health;
    public GameObject[] positions;
    public EnemyAI enemyAI;
    bool phase1_run = false;
    bool phase2_run = false;
    bool phase3_run = false;
    //Phase 1: 60-41HP - summons rats every few seconds
    //Phase 2: 40-21HP - Invulnerable Takes damage only from items on floor
    //Phase 2: 20-0HP - summons plagued and rats every few seconds

    private void Update()
    {
        if (enemyAI.playerInSightRange)
        {
            if (health.health > 41)
            {
                PhaseOne();
            }
            else if (health.health > 21)
            {
                PhaseTwo();
            }
            else
            {
                PhaseThree();
            }
        }
    }
    public void PhaseOne()
    {
        if (summonTimer < 5)
        {
            summonTimer += Time.deltaTime;
        }
        else
        {
            summonTimer = 0;
            Instantiate(rat, transform.position, Quaternion.identity);
        }
        phase1_run = true;
    }
    public void PhaseTwo()
    {
        if (phase2_run == false)
        {
            health.isInvulnerable = true;
            foreach (GameObject posOBJ in positions)
            {
                Instantiate(damage_item, posOBJ.transform.position, Quaternion.identity);
            }
        }
        phase2_run = true;
    }
    public void PhaseThree()
    {
        health.isInvulnerable = false;
        if (summonTimer < 5)
        {
            summonTimer += Time.deltaTime;
        }
        else
        {
            summonTimer = 0;
            Instantiate(rat, transform.position, Quaternion.identity);
            Instantiate(plagued, transform.position, Quaternion.identity);
        }
        phase3_run = true;
    }
}

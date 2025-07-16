using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject healthOBJ;
    public Image healthBar;
    public TextMeshProUGUI healthText;

    public Sprite p2_sprite;
    public Sprite p3_sprite;
    private void Update()
    {
        if (enemyAI.playerInSightRange)
        {
            healthText.text = health.health.ToString() + "/" + health.maxHealth.ToString();
            healthBar.fillAmount = (float)(health.health) / (float)(health.maxHealth);
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
        if (phase1_run == false)
        {
            healthOBJ.SetActive(true);
        }
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
            healthBar.sprite = p2_sprite;
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
        if (phase3_run == false)
        {
            healthBar.sprite = p3_sprite;
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    public LayerMask whatIsPlayer, whatIsGround;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAtacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Stats
    int Damage = 1;

    float timer = 0;
    int timeOnTarget = 4;
    bool canSwitch = false;
    //unity events
    public UnityEvent attacking;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
            canSwitch = true;
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, whatIsPlayer);

        playerInAttackRange = false;

        foreach (Collider col in hitColliders)
        {
            if (col.tag == "Player")
            {
                playerInAttackRange = true;
                break; // Optional: stop at first match
            }
        }
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }
    public void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        else
        {
            agent.SetDestination(walkPoint);
            Vector3 direction = (walkPoint - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f || canSwitch)
        {
            
            timer = 4;
            canSwitch = false;
            walkPointSet = false;
        }
        Debug.Log("Patrolling");
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x +randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    public void ChasePlayer()
    {
        agent.SetDestination(player.position);
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        Debug.Log("Chasing");
    }
    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        if (!alreadyAtacked)
        {
            //ATTACK CODE HERE
            player.GetComponent<Damageable>().ReduceHealth(Damage);
            attacking?.Invoke();
            alreadyAtacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        Debug.Log("Attacking");
    }

    private void ResetAttack()
    {
        alreadyAtacked = false;
    }
}

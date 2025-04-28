using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlaguedAddons : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    Coroutine stun;
    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    public void Attacking()
    {
        animator.SetTrigger("attacked");
    }
    public void Damaged()
    {
        animator.SetTrigger("damaged");
        if (stun != null)
            StopCoroutine(stun);
        stun = StartCoroutine(StunCoroutine());
    }

    IEnumerator StunCoroutine()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(0.5f);
        agent.isStopped = false;
    }
}

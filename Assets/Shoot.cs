using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Animator animator;
    GameStateManager stateManager;
    private void Start()
    {
        animator = GetComponent<Animator>();   
        stateManager = GameObject.Find("GameManager").GetComponent<GameStateManager>();
    }
    private void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(1).IsName("ScopeGun") && !animator.GetCurrentAnimatorStateInfo(1).IsName("ShootGun"))
        {
            EndScope();
        }
        else
        {
            StartScope();
        }
    }
    public void EndFire()
    {
        animator.SetBool("isFiring", false);
    }
    public void StartFire()
    {

    }
    public void StartScope()
    {
        stateManager.ScopeState();
    }
    public void EndScope()
    {
        stateManager.PlayState();
    }
}

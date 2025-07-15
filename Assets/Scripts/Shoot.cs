using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Animator animator;
    GameStateManager stateManager;
    public Camera mainCamera;
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
        animator.SetFloat("ShotSpeed", ((RangedWeapon)InventoryManager.items[0]).ShotSpeed);
        SFXManager.Instance.PlaySFX(((RangedWeapon)InventoryManager.items[0]).shotSFX, 0.1f);
        Vector3 mousePos = Input.mousePosition;
        Vector3 viewportPoint = new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0);
        Ray ray = mainCamera.ViewportPointToRay(viewportPoint);

        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit))
        {
            // Get the point where the ray hit
            Vector3 hitPoint = hit.point;
            if (hit.transform.gameObject.GetComponent<Damageable>() != null)
            {
                hit.transform.gameObject.GetComponent<Damageable>().ReduceHealth(((RangedWeapon)InventoryManager.items[0]).DamageOnHit);
                Debug.Log("shot fired at: " + hit.transform.gameObject.name);
            }
        }
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

using UnityEngine;

public class WeaponAnimationController : AnimationController
{
    private WeaponController controller;
    private void Start()
    {
        controller = GetComponent<WeaponController>();
        controller.attackAction += Attacking;
    }

    private void Attacking()
    {
        animator.SetTrigger("Attack");
        
    }
}
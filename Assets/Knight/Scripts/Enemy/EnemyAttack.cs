using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    protected LayerMask attackMask;
    public Transform attackPoint;

    public PowerData powerData;
    public Animator animator;

    private void Awake()
    {
        attackMask = LayerMask.GetMask("Player");
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }


    public void CallAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, powerData.attackRange, attackMask);

        foreach (Collider2D enemy in hitPlayer)
        {
            Debug.Log(enemy.name);
            enemy.GetComponent<PlayerDamagable>().TakeDamage(powerData.attackDamage);
        }
    }

    protected virtual void EnragedAttack() { }
    
         


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, powerData.attackRange);
    }

    
}

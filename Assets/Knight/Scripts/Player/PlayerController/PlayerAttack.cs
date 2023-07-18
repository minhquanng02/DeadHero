using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PowerData powerData;

    private float timeSinceAttack = 0.0f;
    private int currentAttack = 0;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    private float nextAttackTime = 0f; 

    public void Attack()
    {
       if(Time.time >= nextAttackTime)
        {
            if (!PlayerRoll.IsRoll && !PlayerWallSlide.IsWallSliding)
            {
                AttackAnim();

                AudioManager.Instance.PlaySFX("Attack");
                nextAttackTime = Time.time + 1f / powerData.attackRate;
            }
        }
            
    }
    private void Update()
    {
        timeSinceAttack += Time.deltaTime;
    }

    private void AttackAnim()
    {
        if (timeSinceAttack > 0.25f)
        {
            
            currentAttack++;

            // Loop back to one after third attack
            if (currentAttack > 3)
                currentAttack = 1;

            // Reset Attack combo if time since last attack is too large
            if (timeSinceAttack > 1.0f)
                currentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            PlayerSystem.Animator.SetTrigger("Attack" + currentAttack);

            // Reset timer
            timeSinceAttack = 0.0f;
        }
    }

    public void Damage()
    {
        Debug.Log("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, powerData.attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("hit" + enemy.name);
            if (enemy.CompareTag("Boss"))
            {
                enemy.GetComponent<BossDamagable>().TakeDamage(powerData.attackDamage);
            }
            else enemy.GetComponent<EnemyDamagable>().TakeDamage(powerData.attackDamage);
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, powerData.attackRange);
    }
}

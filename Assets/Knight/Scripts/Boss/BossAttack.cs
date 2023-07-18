using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack
{
    protected override void EnragedAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, powerData.attackRange, attackMask);

        foreach (Collider2D enemy in hitPlayer)
        {
            enemy.GetComponent<PlayerDamagable>().TakeDamage(powerData.EnragedAttackDamage);
        }
    }
}

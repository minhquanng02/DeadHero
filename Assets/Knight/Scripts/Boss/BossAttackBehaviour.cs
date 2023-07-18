using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackBehaviour : AIAttackBehaviour
{
   /* public BossDamagable enemyDmg;

    public override void AttackBehaviour(AIDetector detector)
    {
        if (!playerDmg.isDead)
        {
            animator.SetBool("IsWalk", true);
            enemy.LookAtPlayer();
            Vector2 target = new Vector2(detector.Target.position.x, rgb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rgb.position, target, powerData.speed * Time.fixedDeltaTime);
            rgb.MovePosition(newPos);

            if (Vector2.Distance(detector.Target.position, rgb.position) <= powerData.attackRange && !playerDmg.isDead && !enemyDmg.isInvulnerable)
            {
                enemyAttack.Attack();
            }
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }
    }*/
}

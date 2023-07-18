using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackBehaviour : MonoBehaviour
{
    protected EnemyAttack enemyAttack;
    protected PlayerDamagable playerDmg;
    protected Rigidbody2D rgb;
    protected EnemyFlip enemy;

    public Animator animator;
    public PowerData powerData;

    protected void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        playerDmg = GameObject.Find("Player").GetComponent<PlayerDamagable>();
        rgb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<EnemyFlip>();
    }

    public virtual void AttackBehaviour(AIDetector detector)
    {
        if (!playerDmg.isDead)
        {
            animator.SetBool("IsWalk", true);

            enemy.LookAtPlayer();

            Vector2 target = new Vector2();

            if (rgb.position.x < detector.Target.position.x)
                target = new Vector2(detector.Target.position.x -1f, rgb.position.y);
            else target = new Vector2(detector.Target.position.x + 1f, rgb.position.y);



            Vector2 newPos = Vector2.MoveTowards(rgb.position, target, powerData.speed * Time.fixedDeltaTime);
            rgb.MovePosition(newPos);

            if (Vector2.Distance(detector.Target.position, rgb.position) <= powerData.attackRange && !playerDmg.isDead)
            {
                enemyAttack.Attack();
            }
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }

    }
}

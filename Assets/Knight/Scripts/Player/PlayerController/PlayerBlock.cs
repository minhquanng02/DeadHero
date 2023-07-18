using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    private static bool isBlock = false;
    public static bool IsBlock { get => isBlock; set => isBlock = value; }

    private static bool isParry = false;
    public static bool IsParry { get => isParry; }

    private float blockCurrentTime;
    private float blockDuration = 2f;

    public PowerData powerData;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public ObjectPool objectPool;




    public void Block()
    {
       
        if (!PlayerRoll.IsRoll && Time.time >= blockCurrentTime)
        {
            Debug.Log("block");
            isParry = true;
            StartCoroutine(ResetIsParry());

            isBlock = true;
            blockCurrentTime = Time.time + 1f / blockDuration;

            PlayerSystem.Animator.SetTrigger("Block");
            PlayerSystem.Animator.SetBool("BlockIdle", true);
        }               
    }

    IEnumerator ResetIsParry()
    {
        yield return new WaitForSeconds(0.3f);
        isParry = false;
    }

    public void Parry()
    {
        Debug.Log("parry");
        AudioManager.Instance.PlaySFX("Block");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, powerData.attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Boss"))
            {
                enemy.GetComponent<BossDamagable>().TakeDamage(powerData.attackDamage);
            }
            else enemy.GetComponent<EnemyDamagable>().TakeDamage(powerData.attackDamage);
        }

        ParryEffect();

    }

    public void ParryEffect()
    {
        GameObject effect = objectPool.instance.GetPooledObject();

        if (effect != null)
        {         
            effect.transform.position = attackPoint.position;
            effect.SetActive(true);
        }
    }

    

}

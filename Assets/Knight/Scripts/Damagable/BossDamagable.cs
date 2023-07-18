using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamagable : Damagable
{
    public bool isInvulnerable = false;
    public GameObject fightMusic;

    [SerializeField] private GameObject victoryUI;



    public override void TakeDamage(int attackDamage)
    {
        if (isInvulnerable)
        {
            return;
        }

        base.TakeDamage(attackDamage);

        if (currentHealth <= powerData.lowHealth && !isDead)
        {
            animator.SetBool("IsEnraged", true);
        }
       
    }

    protected override void Die()
    {
        base.Die();

        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.PlaySFX("Victory");
        StartCoroutine(WaitVictory());

    }

    IEnumerator WaitVictory()
    {
        yield return new WaitForSeconds(2f);
        victoryUI.SetActive(true);
    }

}

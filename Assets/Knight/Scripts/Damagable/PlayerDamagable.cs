using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagable : Damagable
{
    protected PlayerInput playerInput;
    protected PlayerBlock playerBlock;

    [SerializeField] private GameObject gameOverUI;


    protected override void Start()
    {
        base.Start();
        playerInput = GetComponent<PlayerInput>();
        playerBlock = GameObject.Find("PlayerBlock").GetComponent<PlayerBlock>();
        cld = PlayerSystem.Cld;
        rgb = PlayerSystem.Rgb;
        if (animator == null)
        animator = PlayerSystem.Animator;
    }
    public override void TakeDamage(int attackDamage)
    {
        if (PlayerBlock.IsParry)
        {
            //Debug.Log("parry");

            attackDamage = 0;
            playerBlock.Parry();
        }
        else if (PlayerRoll.IsRoll)
        {
            attackDamage = 0;
        }
        else if (PlayerBlock.IsBlock)
        {
            attackDamage /= 2;
            currentHealth -= attackDamage;
            animator.SetTrigger("Hurt");
            AudioManager.Instance.PlaySFX("Hurt");
        }
        else
        {
            currentHealth -= attackDamage;
            animator.SetTrigger("Hurt");
            AudioManager.Instance.PlaySFX("Hurt");
        }

        healthBar.SetHealth(currentHealth);


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    

    protected override void Die()
    {
        base.Die();
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.PlaySFX("Dead");
        StartCoroutine(WaitGameOver());


        playerInput.enabled = false;
    }

    IEnumerator WaitGameOver()
    {
        yield return new WaitForSeconds(2f);
        gameOverUI.SetActive(true);
    }
}

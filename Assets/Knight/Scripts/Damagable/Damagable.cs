using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Damagable : MonoBehaviour
{
    protected Collider2D cld;
    protected Rigidbody2D rgb;

    public Animator animator;
    public PowerData powerData;
    public HealthBar healthBar;

    public int currentHealth = 0;
    public bool isDead = false;

    protected int waitTime = 5;


    protected virtual void Start()
    {
        cld = GetComponent<Collider2D>();
        rgb = GetComponent<Rigidbody2D>();

        if (currentHealth == 0)
            currentHealth = powerData.maxHealth;
        healthBar.SetMaxHealth(powerData.maxHealth);
        healthBar.SetHealth(currentHealth);

    }

    public virtual void TakeDamage(int attackDamage)
    {     
            currentHealth -= attackDamage;

            healthBar.SetHealth(currentHealth);

            animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }      
    }

    protected virtual void Die()
    {
        isDead = true;
        animator.SetBool("IsDead", true);

        cld.enabled = false;
        rgb.bodyType = RigidbodyType2D.Static;
        this.enabled = false;
  
        Invoke("DestroyOnDead", waitTime);
    }

    void DestroyOnDead()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpell : MonoBehaviour
{
    private Rigidbody2D rgb;
    private int spellDmg = 100;
    private LayerMask attackMask;

    public ObjectPool objectPool;




    private void Awake()
    {
        rgb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        attackMask = LayerMask.GetMask("Player");
    }

    public void SpellDamage()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y), new Vector2(2f, 10f), attackMask);

        foreach (Collider2D enemy in hitPlayer)
        {
            if (enemy.CompareTag("Player"))
                enemy.GetComponent<PlayerDamagable>().TakeDamage(spellDmg);
        }
    }

    public void CastSpell()
    {
        GameObject spell = objectPool.instance.GetPooledObject();

        if (spell != null)
        {
            spell.transform.position = new Vector3(rgb.position.x, -57.35f, 0);
            spell.SetActive(true);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(2f, 10f, 0));
    }

}




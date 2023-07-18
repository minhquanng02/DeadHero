using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUtil : MonoBehaviour
{
    public EnemyDamagable enemyDmg;
    public int waitTime;

    private void Update()
    {
        if (enemyDmg.isDead)
        {
            Invoke("DestroyOnDead", waitTime);
        }
    }
    public void DestroyOnDead()
    {
        Destroy(gameObject);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    private Transform player;
    private Vector3 localScale;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    public void LookAtPlayer()
    {
        localScale = transform.localScale;

        if ((transform.position.x > player.position.x && localScale.x > 0) || (transform.position.x < player.position.x && localScale.x < 0))
        {
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    
}

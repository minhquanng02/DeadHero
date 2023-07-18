using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolPathBehaviour : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB;

    public PowerData powerData;
    public Animator animator;
    private PlayerDamagable playerDmg;

    private float waitTime = 2f; 

    private Vector3 target; 
    private bool isWaiting = false;
    private Vector3 localScale;

    public void Awake()
    {
        playerDmg = GameObject.Find("Player").GetComponent<PlayerDamagable>();
    }

    public void Start()
    {
        target = pointA.position;
        localScale = transform.localScale;
        
    }

    public void PatrolBehaviour(AIDetector detector)
    {
        Flip();

        if (!isWaiting && !playerDmg.isDead)
        {
            MoveToTarget();
        }       
    }

    public void MoveToTarget()
    {
        animator.SetBool("IsWalk", true);
        transform.position = Vector3.MoveTowards(transform.position, target, powerData.speed * Time.deltaTime);
        

        if (transform.position == target)
        {
            StartCoroutine(WaitAndSwitchTarget());           
        }
    }

    public IEnumerator WaitAndSwitchTarget()
    {
        animator.SetBool("IsWalk", false);
        isWaiting = true; 
        yield return new WaitForSeconds(waitTime); 
        isWaiting = false;
        if (target == pointA.position)
        { 
            target = pointB.position;
            
        }
        else
        {
            target = pointA.position;            
        }
    }

    public void Flip()
    {
        if ((  transform.position.x > target.x && localScale.x > 0) || ( transform.position.x < target.x && localScale.x < 0))
        {
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(pointA.position, pointB.position);
    }
}



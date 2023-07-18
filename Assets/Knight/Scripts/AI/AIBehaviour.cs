using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    private AIAttackBehaviour attackBehaviour;
    private AIPatrolPathBehaviour patrolPathBehaviour;

    private void Awake()
    {
        attackBehaviour = GetComponent<AIAttackBehaviour>();
        patrolPathBehaviour = GetComponent<AIPatrolPathBehaviour>();
    }
    public void AIAttackBehaviour(AIDetector detector)
    {
        attackBehaviour.AttackBehaviour(detector);
    }

    public void AIPatrolBehaviour(AIDetector detector)
    {
        patrolPathBehaviour.PatrolBehaviour(detector);
    }

}

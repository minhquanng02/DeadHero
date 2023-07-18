using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefauftEnemyAI : MonoBehaviour
{
    private AIBehaviour aiBehaviuor;

    private AIDetector detector;


    private void Awake()
    {
        detector = GetComponentInChildren<AIDetector>();
        aiBehaviuor = GetComponent<AIBehaviour>();
    }

    private void Update()
    {
        
            if (detector.Target != null)
            {
                aiBehaviuor.AIAttackBehaviour(detector);
            }
            else
            {
                aiBehaviuor.AIPatrolBehaviour(detector);
            }
    }
}

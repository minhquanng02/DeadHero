using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform attackPoint;
    public ObjectPool objectPool;
    public void Shooting()
    {
        GameObject arrow = objectPool.instance.GetPooledObject();

        if (arrow != null)
        {
            if (transform.parent.localScale.x > 0)
                arrow.transform.rotation = Quaternion.Euler(0, 180, 0);
            else arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
            arrow.transform.position = attackPoint.position;
            arrow.SetActive(true);
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    private static bool isWall;
    public static bool IsWall { get => isWall; }

    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    

    void Update()
    {
        IsWalled();
    }
   

    private void IsWalled()
    {
        if (Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer))
        {
            isWall = true;
        }
        else isWall = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    private static bool isFacingRight = true;
    public static bool IsFacingRight { get => isFacingRight; set => isFacingRight = value; }

    public void Flip(float horizontal)
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {

            Vector3 localScale = transform.parent.parent.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.parent.parent.localScale = localScale;
        }
    }

    
}

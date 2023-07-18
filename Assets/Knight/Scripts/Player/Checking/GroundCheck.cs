using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private static bool isGround;
    public static bool IsGround { get => isGround; }

    private void IsGrounded()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer))
        { isGround = true; }
        else isGround = false;
    }

    private void Update()
    {
        IsGrounded();
    }
}

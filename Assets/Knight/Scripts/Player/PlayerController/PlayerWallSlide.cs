using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlide : MonoBehaviour
{
    private static bool isWallSliding;
    public static bool IsWallSliding { get => isWallSliding; }

    private float wallSlidingSpeed = 2f;

    public void WallSlide()
    {

        if (WallCheck.IsWall && !GroundCheck.IsGround && PlayerInput.Horizontal != 0f && !PlayerWallJump.IsWallJumping)
        {
            isWallSliding = true;
            PlayerSystem.Rgb.velocity = new Vector2(PlayerSystem.Rgb.velocity.x, Mathf.Clamp(PlayerSystem.Rgb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }

        PlayerSystem.Animator.SetBool("WallSlide", isWallSliding);

    }
}

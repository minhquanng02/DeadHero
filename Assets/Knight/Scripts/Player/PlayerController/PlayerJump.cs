using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    
    private bool doubleJump; 
    private float jumpingPower = 25f;

    private float jumpTime = 0.2f;
    private float jumpTimeCounter;

   


    public void Jump()
    {
        Debug.Log("jump");

        
        if (GroundCheck.IsGround)
        {
            PlayerSystem.Animator.SetTrigger("Jump");
            AudioManager.Instance.PlaySFX("Jump");

            PlayerSystem.Rgb.velocity = new Vector2(PlayerSystem.Rgb.velocity.x, jumpingPower);
        }

        
        if (jumpTimeCounter > 0f && (GroundCheck.IsGround || doubleJump))
        {
            PlayerSystem.Animator.SetTrigger("Jump");
            AudioManager.Instance.PlaySFX("Jump");

            PlayerSystem.Rgb.velocity = new Vector2(PlayerSystem.Rgb.velocity.x, jumpingPower);

            doubleJump = !doubleJump;
        }

        if (PlayerSystem.Rgb.velocity.y > 0f)
        {
            PlayerSystem.Rgb.velocity = new Vector2(PlayerSystem.Rgb.velocity.x, PlayerSystem.Rgb.velocity.y * 0.5f);

            jumpTimeCounter = 0f;
        }
    }

    

    private void Update()
    {
        PlayerSystem.Animator.SetBool("IsGround", GroundCheck.IsGround);

        if (GroundCheck.IsGround)
        {
            jumpTimeCounter = jumpTime;
        }
        else
        {
            jumpTimeCounter -= Time.deltaTime;
        }

    }
}

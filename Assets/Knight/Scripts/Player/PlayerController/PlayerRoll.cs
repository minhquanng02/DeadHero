using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    private float rollForce = 10f;

    private float rollCurrentTime;
    private float rollDuration = 1.5f;

    private static bool isRoll = false;
    public static bool IsRoll { get => isRoll; }


    public void Roll()
    {

        if (!isRoll && !PlayerWallSlide.IsWallSliding)
        {
            Debug.Log("roll");
            isRoll = true;
            rollCurrentTime = Time.time + 1f / rollDuration;
            PlayerSystem.Rgb.velocity = new Vector2(rollForce, PlayerSystem.Rgb.velocity.y);

            AudioManager.Instance.PlaySFX("Roll");
            PlayerSystem.Animator.SetTrigger("Roll");
        }

        
    }

    private void Update()
    {
        if (Time.time >= rollCurrentTime)
        {
            isRoll = false;
        }
    }
}

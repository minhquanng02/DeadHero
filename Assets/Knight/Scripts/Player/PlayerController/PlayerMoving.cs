using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{

    public PowerData powerData;


    public void Move(float horizontal)
    {
        if (!PlayerBlock.IsBlock)
        {
            PlayerSystem.Rgb.velocity = new Vector2(horizontal * powerData.speed, PlayerSystem.Rgb.velocity.y);
            PlayerSystem.Animator.SetFloat("Speed", Mathf.Abs(horizontal));
            PlayerSystem.Animator.SetFloat("SpeedY", PlayerSystem.Rgb.velocity.y);
        }       
    }

    private void Update()
    {
        if (powerData == null)
            Debug.Log("add power data plz");
    }

   
}

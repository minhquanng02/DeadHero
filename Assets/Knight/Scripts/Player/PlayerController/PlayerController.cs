using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{  
    private PlayerJump playerJump;
    private PlayerWallJump playerWallJump;
    private PlayerWallSlide playerWallSlide;
    private PlayerJumpDown playerJumpDown;
    private PlayerAttack playerAttack;
    private PlayerBlock playerBlock;
    private PlayerBlockIdle playerBlockIdle;
    private PlayerMoving playerMoving;
    private PlayerFlip playerFlip;
    private PlayerRoll playerRoll;
    private PlayerTeleport playerTeleport;


    private void Awake()
    {
            playerJump = GetComponentInChildren<PlayerJump>();
            playerWallSlide = GetComponentInChildren<PlayerWallSlide>();
            playerWallJump = GetComponentInChildren<PlayerWallJump>();
            playerJumpDown = GetComponentInChildren<PlayerJumpDown>();
            playerAttack = GetComponentInChildren<PlayerAttack>();
            playerBlock = GetComponentInChildren<PlayerBlock>();
            playerBlockIdle = GetComponentInChildren<PlayerBlockIdle>();
            playerMoving = GetComponentInChildren<PlayerMoving>();      
            playerFlip = GetComponentInChildren<PlayerFlip>();      
            playerRoll = GetComponentInChildren<PlayerRoll>();
            playerTeleport = GetComponentInChildren<PlayerTeleport>();
    }

    public void HandleJump()
    {
        playerJump.Jump();
        playerWallJump.WallJump();
    }

    public void HandleTele()
    {
        playerTeleport.Tele();
    }

    public void HandleWallSLide()
    {
        playerWallSlide.WallSlide();
    }

    public void HandleJumpDown()
    {
        playerJumpDown.JumpDown();
    }

    public void HandleRoll()
    {
        playerRoll.Roll();
    }

    public void HandleAttack()
    {
        playerAttack.Attack();
    }

    public void HandleBlock()
    {
        playerBlock.Block();    
    }

    public void HandleBlockIdle()
    {
        playerBlockIdle.BlockIdle();
    }

    public void HandleMove(float horizontal)
    {
        playerMoving.Move(horizontal);     
    }

    public void HandleFlip(float horizontal)
    {
        playerFlip.Flip(horizontal);
    }
}

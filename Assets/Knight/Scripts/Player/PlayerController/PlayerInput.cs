using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class PlayerInput : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;

    public UnityEvent OnAttack = new UnityEvent();
    public UnityEvent OnBlock = new UnityEvent();
    public UnityEvent OnBlockIdle = new UnityEvent();
    public UnityEvent OnJump = new UnityEvent();
    public UnityEvent OnJumpDown = new UnityEvent();
    public UnityEvent OnRoll = new UnityEvent();
    public UnityEvent OnInteract = new UnityEvent();
    public UnityEvent OnWallSlide = new UnityEvent();
    public UnityEvent<float> OnMove = new UnityEvent<float>();
    public UnityEvent<float> OnFlip = new UnityEvent<float>();

    private static float horizontal;
    public static float Horizontal { get => horizontal; }


    private void Update()
    {
        GetHorizontal();
        GetPlayerMove(horizontal);
        GetPlayerJump();
        GetPlayerJumpDown();
        GetPlayerRoll();
        GetPlayerAttack();
        GetPlayerFlip(horizontal);
        GetPlayerWallSlide();
        GetPlayerInteract();
    }

    private void GetHorizontal()
    {
        horizontal = joystick.Horizontal;
        if (horizontal > 0)
            horizontal = 1;
        else if (horizontal < 0)
            horizontal = -1;
    }


    private void GetPlayerRoll()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnRoll?.Invoke();
        }
    }

    private void GetPlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            OnJump?.Invoke();
        }
    }

    private void GetPlayerWallSlide()
    {
        OnWallSlide?.Invoke();
    }

    private void GetPlayerJumpDown()
    {
        if (Input.GetButtonDown("Down"))
        {
            OnJumpDown?.Invoke();
        }

        if (joystick.Vertical < -0.5)
        {
            OnJumpDown?.Invoke();
        }
    }

    private void GetPlayerInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteract?.Invoke();
        }
    }

    private void GetPlayerBlock()
    {
        OnBlock?.Invoke();
    }

    private void GetPlayerBlockIdle()
    {
        OnBlockIdle?.Invoke();
    }

    private void GetPlayerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnAttack?.Invoke();
        }
    }


    private void GetPlayerMove(float horizontal)
    {     
        OnMove?.Invoke(horizontal);
    }

    private void GetPlayerFlip(float horizontal)
    {
        OnFlip?.Invoke(horizontal);
    }
}

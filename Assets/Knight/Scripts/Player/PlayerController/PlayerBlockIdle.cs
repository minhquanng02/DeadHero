using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockIdle : MonoBehaviour
{

    public void BlockIdle()
    {
        PlayerBlock.IsBlock = false;
        PlayerSystem.Animator.SetBool("BlockIdle", false);
    }
}

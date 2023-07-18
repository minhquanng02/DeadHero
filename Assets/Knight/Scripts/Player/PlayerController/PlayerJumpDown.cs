using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpDown : MonoBehaviour
{
    private OneWayPlatformCheck oneWayPlatformCheck;

    private void Awake()
    {
        oneWayPlatformCheck = GameObject.Find("Player").GetComponent<OneWayPlatformCheck>();
    }

    public void JumpDown()
    {
        if (oneWayPlatformCheck.currentOneWayPlatform != null)
        {
            Debug.Log("down");
            StartCoroutine(DisableCollision());
        }
    }

    

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = oneWayPlatformCheck.currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(PlayerSystem.Cld, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(PlayerSystem.Cld, platformCollider, false);
    }
}


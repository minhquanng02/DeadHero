using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    private static Animator animator;
    public static Animator Animator { get => animator; }

    private static Rigidbody2D rgb;
    public static Rigidbody2D Rgb { get => rgb; }

    private static BoxCollider2D cld;
    public static BoxCollider2D Cld { get => cld; }

    private void Awake()
    {
        animator = GameObject.Find("PlayerSprite").GetComponent<Animator>();
        rgb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        cld = GameObject.Find("Player").GetComponent<BoxCollider2D>();
    }
}

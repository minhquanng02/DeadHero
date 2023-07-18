using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private static AudioSource sound;
    public static AudioSource Sound { get => sound; }

    public static AudioClip themeSound;
    public AudioClip ThemeSound;


    public static AudioClip jumpSound;
    public AudioClip JumpSound;

    public static AudioClip attackSound;
    public AudioClip AttackSound;

    public static AudioClip hurtSound;
    public AudioClip HurtSound;

    public static AudioClip rollSound;
    public AudioClip RollSound;

    public static AudioClip blockSound;
    public AudioClip BlockSound;

    public static AudioClip death;
    public AudioClip Death;

    public static AudioClip victory;
    public AudioClip Victory;

    public static AudioClip fighting;
    public AudioClip Fighting;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        jumpSound = JumpSound;
        attackSound = AttackSound;
        hurtSound = HurtSound;
        rollSound = RollSound;
        death = Death;
        victory = Victory;
        fighting = Fighting;
        blockSound = BlockSound;
        themeSound = ThemeSound;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerData", menuName = "Data/PowerData")]
public class PowerData : ScriptableObject
{
    public int maxHealth = 100;
    public int lowHealth;
    public int attackDamage = 40;
    public int EnragedAttackDamage = 60;

    public float attackRate = 2;
    public float attackRange = 1f;

    public float speed = 8;
}

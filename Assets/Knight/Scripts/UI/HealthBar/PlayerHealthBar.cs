using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : HealthBar
{
    public Gradient gradient;

    public override void SetMaxHealth(int health)
    {
        base.SetMaxHealth(health);
        fill.color = gradient.Evaluate(1f);
    }

    public override void SetHealth(int health)
    {
        base.SetHealth(health);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

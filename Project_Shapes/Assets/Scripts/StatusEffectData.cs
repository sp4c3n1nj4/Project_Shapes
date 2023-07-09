using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum StatusEffect
{
    slow,
    damageDown,
    mechanic
}

[Serializable]
public class StatusEffectData
{
    public string Name;
    public StatusEffect effect;

    public float duration;
}

[Serializable]
public class SlowStatus : StatusEffectData
{
    public new string Name = "Slow";
    public new StatusEffect effect = StatusEffect.slow;
}

[Serializable]
public class DamageDownStatus : StatusEffectData
{
    public new string Name = "Damage Down";
    public new StatusEffect effect = StatusEffect.damageDown;
}

[Serializable]
public class MechanicStatus1 : StatusEffectData
{
    public new string Name = "Mechanic 1";
    public new StatusEffect effect = StatusEffect.mechanic;
}

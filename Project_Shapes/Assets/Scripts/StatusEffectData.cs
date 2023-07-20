using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum StatusEffect
{
    //the different effects a status can have
    slow,
    damageDown,
    mechanic
}

[Serializable]
public class StatusEffectData
{
    // a class to hold the details of a status effect
    public string Name;
    public StatusEffect effect;

    public float duration;
}

//bellow is unused

//[Serializable]
//public class SlowStatus : StatusEffectData
//{
//    string Name = "Slow";
//    StatusEffect effect = StatusEffect.slow;
//}

//[Serializable]
//public class DamageDownStatus : StatusEffectData
//{
//    public string Name = "Damage Down";
//    public StatusEffect effect = StatusEffect.damageDown;
//}

//[Serializable]
//public class MechanicStatus1 : StatusEffectData
//{
//    public string Name = "Mechanic 1";
//    public StatusEffect effect = StatusEffect.mechanic;
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BossAbilities
{
    //parent class for all boss abilities
    public float time;
}

public enum BossAbilityTarget
{
    //enum to select the different target for the movement
    none,
    boss,
    player
}

[Serializable]
public class BossMove : BossAbilities
{
    //child class for boss movement
    public float moveDuration;

    //the centre of the move to which the offset is added to get the desired target
    public BossAbilityTarget target;

    public bool random = false;
    public Vector2[] offSet;
}

[Serializable]
public class BossAttack : BossAbilities
{
    //child class for boss attacks
    public HitBoxAttack[] boxAttacks;
}

public enum HitBoxType
{
    //enum to differentiate between the hitbox types
    Cube,
    Cylinder,
    Donut
}

public enum HitBoxEffect
{
    damage,
    continous,
    knockback,
    tower
}

[Serializable]
public class HitBoxAttack
{
    //class hold all the necessary variables to instantiate a hitbox
    public HitBoxType hitBoxType;

    //cast time and effect get passed to hit box on Instantiate
    public float castTime;

    public HitBoxEffect[] effect;
    public float hitBoxDuration = 0;
    public Vector2 direction = Vector2.zero;
    public float damage = 0;

    public StatusEffectData[] status = new StatusEffectData[0];
    public float statusDuration = 0;
    public StatusEffectData[] cleanseStatus = new StatusEffectData[0];

    //scale and rotation get set durant instantiate
    public Vector2 scale;    
    public float Yrotation;

    //the centre of the move to which the offset is added to get the desired target
    public BossAbilityTarget target;
    public bool random = false;
    public Vector2[] offSet;
}
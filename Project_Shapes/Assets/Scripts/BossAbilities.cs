using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization;

//implementiong Vector2 Serialization Surrogate as Vector2 is not Serialized Innately
[Serializable]
public class Vector2Surrogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        Vector2 vector2 = (Vector2)obj;
        info.AddValue("x", vector2.x);
        info.AddValue("y", vector2.y);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        Vector2 vector2 = (Vector2)obj;
        vector2.x = info.GetSingle("x");
        vector2.y = info.GetSingle("y");
        return vector2;
    }
}

[Serializable]
public class BossAbilities
{
    //parent class for all boss abilities
    public float time;
}

[Serializable]
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
    public float moveSpeed = 1f;

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

[Serializable]
public enum HitBoxType
{
    //enum to differentiate between the hitbox types
    Cube,
    Cylinder,
    Donut
}

[Serializable]
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
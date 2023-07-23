using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization;

//implementiong Vector2 Serialization Surrogate since Vector2 is not Serialized Innately
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
    public Vector2[] offSet = new Vector2[1] { Vector2.zero };
}

[Serializable]
public class BossAttack : BossAbilities
{
    //child class for boss attacks
    public HitBoxAttack[] boxAttacks = new HitBoxAttack[1] { new HitBoxAttack() };
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
    //enum to differentiate between the different effects of hitboxes
    damage,
    continous,
    knockback,
    tower
}

public enum StatusEffect 
{ 
    damageDown,
    slow,
    mechanic
}

[Serializable]
public class HitBoxAttack
{
    //class hold all the necessary variables to instantiate a hitbox
    public HitBoxType hitBoxType = HitBoxType.Cube;

    //cast time and effect get passed to hit box on Instantiate
    public float castTime = 0f;

    //List of Hitbox effects and their relevant variables
    public List<HitBoxEffect> effect = new List<HitBoxEffect>();
    public float hitBoxDuration = 0;
    public Vector2 direction = Vector2.zero;
    public float damage = 0;

    //List of status effects to apply and their duration
    [SerializeReference, SerializeReferenceButton]
    public List<StatusEffect> status = new List<StatusEffect>();
    //List of status effects to remove #not implemented
    [SerializeReference, SerializeReferenceButton]
    public List<StatusEffect> cleanseStatus = new List<StatusEffect>();
    public float statusDuration = 0f;

    //scale and rotation get set durant instantiate
    public Vector2 scale = Vector2.zero;    
    public float Yrotation = 0f;

    //the centre of the move to which the offset is added to get the desired target
    public BossAbilityTarget target = BossAbilityTarget.none;
    public bool random = false;
    public Vector2[] offSet = new Vector2[1] { Vector2.zero };
}
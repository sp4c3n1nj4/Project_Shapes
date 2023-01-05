using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BossAbilities
{
    //parent class for all boss abilities
    public float delayTimer;
}

[Serializable]
public class BossMove : BossAbilities
{
    //child class for boss movement
    public float speed;

    public Vector3 position;
}

[Serializable]
public class BossAttack : BossAbilities
{
    //child class for boss attacks
    public HitBoxAttack[] boxAttacks;
}

[Serializable]
public class HitBoxAttack
{
    //class hold all the necessary variables to instantiate a hitbox
    public hitBoxType hitBoxType;
    public float damage;
    public float x;
    public float y;
    public float time;
    public Vector3 position;
    public Vector3 rotation;
}

public enum hitBoxType
{
    //enum to differentiate between the two hitbox types
    Cube,
    Cylinder
}
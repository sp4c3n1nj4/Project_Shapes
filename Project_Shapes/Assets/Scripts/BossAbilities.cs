using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

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
    Cube,
    Cylinder
}
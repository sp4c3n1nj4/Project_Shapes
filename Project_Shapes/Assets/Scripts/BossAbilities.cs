using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public enum BossAbilityEnum
{
    BossMove,
    BossAttack
}

[Serializable]
public class BossAbilities
{
    [SerializeReference]
    public float delayTimer;
}

[Serializable]
public class BossMove : BossAbilities
{
    [SerializeReference]
    public float speed;
    [SerializeReference]
    public Vector3 position;
}

[Serializable]
public class BossAttack : BossAbilities
{
    [SerializeReference]
    public Vector3 position;
    [SerializeReference]
    public Quaternion rotation;
    [SerializeReference]
    public float damage;
    [SerializeReference]
    public float size;
    
}
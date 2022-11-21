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
public struct BossMoveS
{
    [SerializeField]
    public float delayTimer { get; }
    [SerializeField]
    public float speed { get; }
    [SerializeField]
    public Vector3 position { get; }
}

public struct BossAttack
{
    [SerializeField]
    public float delayTimer { get; }
    [SerializeField]
    public Vector3 position { get; }
    [SerializeField]
    public Quaternion rotation { get; }
    [SerializeField]
    public float damage { get; }
    [SerializeField]
    public float size { get; }
    
}
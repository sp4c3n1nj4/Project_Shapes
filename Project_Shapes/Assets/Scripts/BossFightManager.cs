using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BossFightManager : MonoBehaviour
{
    public List<BossAbilities> bossTimeline;
    [SerializeField]
    private Dictionary<string, Action> bossAbilityDictionary = new Dictionary<string, Action>();

    private void Start()
    {
        var item = bossTimeline[0] as BossMove;
    }

    private void BossMoveFunction(float delayTimer, float speed, Vector3 position)
    {
        
    }
}

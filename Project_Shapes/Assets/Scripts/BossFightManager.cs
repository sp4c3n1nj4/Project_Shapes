using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BossFightManager : MonoBehaviour
{
    [SerializeField]
    private List<BossAbilities> bossTimeline;
    [SerializeField]
    private Dictionary<string, Action> bossAbilityDictionary = new Dictionary<string, Action>();

    private void BossMoveFunction(float delayTimer, float speed, Vector3 position)
    {
        
    }
}

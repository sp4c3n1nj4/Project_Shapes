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
        Debug.Log(bossTimeline[0].delayTimer);

        var item = bossTimeline[0] as BossMove;

        Debug.Log(item.speed);
        Debug.Log(item.position);

    }

    private void BossMoveFunction(float delayTimer, float speed, Vector3 position)
    {
        
    }
}

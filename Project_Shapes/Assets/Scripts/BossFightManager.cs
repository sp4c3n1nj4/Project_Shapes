using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BossFightManager : MonoBehaviour
{
    [SerializeField]
    private List<object> bossTimeline = new List<object>(1) { new BossMoveS() };
    [SerializeField]
    private Dictionary<string, Action> bossAbilityDictionary = new Dictionary<string, Action>();

    private void BossMoveFunction(float delayTimer, float speed, Vector3 position)
    {
        
    }
}

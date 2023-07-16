using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUI : MonoBehaviour
{
    [SerializeField]
    private BossFightManager manager;
    [SerializeField]
    private GameObject gridContent;

    public int index;

    public void UpdateEntry()
    {
        if (manager.bossTimeline[index].GetType().Equals(typeof(BossAttack)))
        {
            DisplayAttackEdit();
        }
        else if (manager.bossTimeline[index].GetType().Equals(typeof(BossMove)))
        {
            DisplayMoveEdit();
        }
    }

    private void DisplayAttackEdit()
    {

    }

    private void DisplayMoveEdit()
    {

    }
}

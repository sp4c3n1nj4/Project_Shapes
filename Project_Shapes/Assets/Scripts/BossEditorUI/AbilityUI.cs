using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class AbilityUI : MonoBehaviour
{
    [SerializeField]
    private BossFightManager manager;
    [SerializeField]
    private GameObject gridContent;
    [SerializeField]
    private GameObject[] moveUI, attackUI;

    private BossAttack bossAttack;
    private BossMove bossMove;

    public void UpdateEntry(int index)
    {
        if (manager.bossTimeline[index].GetType().Equals(typeof(BossAttack)))
        {            
            bossAttack = (BossAttack)manager.bossTimeline[index];
            DisplayAttackEdit();
        }
        else if (manager.bossTimeline[index].GetType().Equals(typeof(BossMove)))
        {            
            bossMove = (BossMove)manager.bossTimeline[index];
            DisplayMoveEdit();
        }
    }

    private void DisplayAttackEdit()
    {
        ToggleUIMode(true);
        print("Attack:");

        BindingFlags bindingFlags = BindingFlags.Public |
                            BindingFlags.NonPublic |
                            BindingFlags.Instance |
                            BindingFlags.Static;
        foreach (FieldInfo field in bossAttack.GetType().GetFields(bindingFlags))
        {
            Debug.Log(field.GetValue(bossAttack));
        }
    }

    private void DisplayMoveEdit()
    {
        ToggleUIMode(false);
        print("Move:");

        BindingFlags bindingFlags = BindingFlags.Public |
                            BindingFlags.NonPublic |
                            BindingFlags.Instance |
                            BindingFlags.Static;
        foreach (FieldInfo field in bossMove.GetType().GetFields(BindingFlags.Public))
        {
            Debug.Log(field.GetValue(bossMove));
        }
    }

    private void ToggleUIMode(bool isAttack)
    {
        for (int i = 0; i < attackUI.Length; i++)
        {
            attackUI[i].SetActive(isAttack);
        }
        for (int i = 0; i < moveUI.Length; i++)
        {
            moveUI[i].SetActive(!isAttack);
        }
    }
}

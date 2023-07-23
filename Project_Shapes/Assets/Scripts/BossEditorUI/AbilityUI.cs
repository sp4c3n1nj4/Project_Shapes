using System.Collections;
using System.Collections.Generic;
//using for more array functionality
using System.Linq;
//using statements to interact with Ui elements
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    [SerializeField]
    private BossFightManager manager;
    [SerializeField]
    private GameObject gridContent;
    [SerializeField]
    private GameObject[] moveUI, attackUI;

    //all UI elements for Boss Moves
    [SerializeField]
    private BossMove bossMove;
    [SerializeField]
    private VirtualBossMove vBossMove;
    [SerializeField]
    private TMP_InputField moveTime, movePositionX, movePositionY;
    [SerializeField]
    private Slider moveSpeed;
    [SerializeField]
    private TMP_Dropdown moveTarget;

    //All UI elements for Boss attacks
    [SerializeField]
    private BossAttack bossAttack;
    [SerializeField]
    private VirtualBossAttack vBossAttack;
    [SerializeField]
    private TMP_InputField attackTime, attackCastTime, attackScaleX, attackScaleY, attackPositionX, attackPositionY, attackDamage, attackDuration,
        attackKnockbackX, attackKnockbackY, attackDDDuration, attackSlowDuration;
    [SerializeField]
    private Slider attackRotation;
    [SerializeField]
    private TMP_Dropdown attackShape, attackTarget;
    [SerializeField]
    private Toggle attackEffectDamage, attackEffectContinous, attackEffectKnockback, attackEffectTower, attackStatusDD, attackStatusSlow;


    public void UpdateEntry(int index)
    {
        if (manager.bossTimeline[index].GetType().Equals(typeof(BossAttack)))
        {            
            bossAttack = (BossAttack)manager.bossTimeline[index];
            vBossAttack.index = index;
            DisplayAttackEdit();
        }
        else if (manager.bossTimeline[index].GetType().Equals(typeof(BossMove)))
        {            
            bossMove = (BossMove)manager.bossTimeline[index];
            vBossMove.index = index;
            DisplayMoveEdit();
        }
    }

    private void DisplayMoveEdit()
    {
        ToggleUIMode(false);
        PopulateMoveUI();

        print("Selected move:");
    }

    private void PopulateMoveUI()
    {
        moveTime.text = bossMove.time.ToString();
        moveSpeed.value = bossMove.moveSpeed;

        int i = 0;
        switch (bossMove.target)
        {
            case BossAbilityTarget.none:
                i = 0;
                break;
            case BossAbilityTarget.boss:
                i = 1;
                break;
            case BossAbilityTarget.player:
                i = 2;
                break;
        }
        moveTarget.value = i;

        movePositionX.text = bossMove.offSet[0].x.ToString();
        movePositionY.text = bossMove.offSet[0].y.ToString();
    }

    private void DisplayAttackEdit()
    {
        ToggleUIMode(true);
        PopulateAttackUI();

        print("Selected attack:");
    }

    private void PopulateAttackUI()
    {
        attackTime.text = bossAttack.time.ToString();
        attackCastTime.text = bossAttack.boxAttacks[0].castTime.ToString();
        int shape = 0;
        switch (bossAttack.boxAttacks[0].hitBoxType)
        {
            case HitBoxType.Cylinder:
                shape = 1;
                break;
            case HitBoxType.Donut:
                shape = 2;
                break;
        }
        attackShape.value = shape;
        attackRotation.value = bossAttack.boxAttacks[0].Yrotation;
        attackScaleX.text = bossAttack.boxAttacks[0].scale.x.ToString();
        attackScaleY.text = bossAttack.boxAttacks[0].scale.y.ToString();

        int target = 0;
        switch (bossAttack.boxAttacks[0].target)
        {
            case BossAbilityTarget.boss:
                target = 1;
                break;
            case BossAbilityTarget.player:
                target = 2;
                break;
        }
        attackTarget.value = target;
        attackPositionX.text = bossAttack.boxAttacks[0].offSet[0].x.ToString();
        attackPositionY.text = bossAttack.boxAttacks[0].offSet[0].y.ToString();

        if (bossAttack.boxAttacks[0].effect.Contains(HitBoxEffect.damage))
        {
            attackEffectDamage.isOn = true;
            attackDamage.text = bossAttack.boxAttacks[0].damage.ToString();
        }
        if (bossAttack.boxAttacks[0].effect.Contains(HitBoxEffect.continous))
        {
            attackEffectContinous.isOn = true;
            attackDuration.text = bossAttack.boxAttacks[0].hitBoxDuration.ToString();
        }
        if (bossAttack.boxAttacks[0].effect.Contains(HitBoxEffect.knockback))
        {
            attackEffectKnockback.isOn = true;
            attackKnockbackX.text = bossAttack.boxAttacks[0].direction.x.ToString();
            attackKnockbackY.text = bossAttack.boxAttacks[0].direction.y.ToString();
        }
        if (bossAttack.boxAttacks[0].effect.Contains(HitBoxEffect.tower))
        {
            attackEffectTower.isOn = true;
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

    public void CloseEditUI()
    {
        gameObject.SetActive(false);
    }

    public void DeleteEntry()
    {

    }
}

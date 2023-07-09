using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[Serializable]
public class BossFightManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hitboxes;
    [SerializeField]
    private CharacterController con;
    [SerializeField]
    private TextMeshProUGUI timerUI;

    //using a custom Unity Package myde by Textus Games, allows to set and save child classes in the editor
    [SerializeReference, SerializeReferenceButton]
    public List<BossAbilities> bossTimeline;

    [SerializeField]
    private int index = 0;
    [SerializeField]
    private float timer = 90;

    private void Start()
    {
        //Sort List to ensure ability to execute first is first
        bossTimeline.Sort((x, y) => x.time.CompareTo(y.time));
    }

    private void Update()
    {
        //advance timer and update ui      
        timer += Time.deltaTime;
        timerUI.text = timer.ToString("N2");

        if (timer > bossTimeline[index].time)
        {
            DoAbility(bossTimeline[index]);
            index++;
        }

        if (timer > bossTimeline[bossTimeline.Count].time)
        {
            EndFight();
            return;
        }
    }

    private void EndFight()
    {
        //End the fight if end of list is reached
        Debug.LogWarning("End of Boss Timeline List reached");
    }

    private void DoAbility(BossAbilities ability)
    {
        //excecute function based on the class given and wait the delay
        if (ability.GetType() == typeof(BossMove))
        {
            var a = ability as BossMove;
            BossMoveFunction(a.moveDuration, a.offSet, a.random, a.target);
            //StartCoroutine(DelayTimer(a.time));
        }
        else if (ability.GetType() == typeof(BossAttack))
        {
            var a = ability as BossAttack;
            BossAttackFunction(a.boxAttacks);
            //StartCoroutine(DelayTimer(a.time));
        }
    }

    private IEnumerator DelayTimer(float timer)
    {
        //wait for specified seconds
        yield return new WaitForSeconds(timer);

        //advance index and continue or end fight
        index += 1;
        if (index == bossTimeline.Count)
            EndFight();
        else
            DoAbility(bossTimeline[index]);
    }

    private Vector3 vectorTrans(Vector2 pos)
    {
        return new Vector3(pos.x, 0, pos.y);
    }

    private void BossMoveFunction(float duration, Vector2[] position, bool random, BossAbilityTarget target)
    {
        int j = 0;
        if (random)
        {
            j = UnityEngine.Random.Range(0, position.Length);
        }

        var motion = Vector3.zero;
        switch (target)
        {
            case BossAbilityTarget.none:
                motion = vectorTrans(position[j]);
                break;
            case BossAbilityTarget.player:
                motion = vectorTrans(position[j]) + con.transform.position;
                break;
            case BossAbilityTarget.boss:
                motion = vectorTrans(position[j]) + this.transform.position;
                break;
        }
        con.Move(motion * duration);
    }

    private void BossAttackFunction(HitBoxAttack[] attacks)
    {
        for (int i = 0; i < attacks.Length; i++)
        {
            int h;
            if (attacks[i].hitBoxType == HitBoxType.Cube)
                h = 0;
            else if (attacks[i].hitBoxType == HitBoxType.Cylinder)
                h = 1;
            else
                h = 2;

            int j = 0;
            if (attacks[i].random)
            {
                j = UnityEngine.Random.Range(0, attacks[i].offSet.Length);
            }

            Vector3 target = Vector3.zero;
            switch (attacks[i].target)
            {
                case BossAbilityTarget.none:
                    target = vectorTrans(attacks[i].offSet[j]);
                    break;
                case BossAbilityTarget.player:
                    target = vectorTrans(attacks[i].offSet[j]) + con.transform.position;
                    break;
                case BossAbilityTarget.boss:
                    target = vectorTrans(attacks[i].offSet[j]) + this.transform.position;
                    break;
            }

            HitBox(h, target, attacks[i]);
        }
    }

    private void HitBox(int index, Vector3 target, HitBoxAttack attack)
    {
        //instantiate a hitbox and set all its variables
        GameObject b = Instantiate(hitboxes[index], target, Quaternion.Euler(0, attack.Yrotation, 0));
        b.transform.localScale = new Vector3(attack.scale.x, b.transform.localScale.y, attack.scale.y);

        b.GetComponent<HitBox>().castTime = attack.castTime;

        b.GetComponent<HitBox>().effect = attack.effect;
        b.GetComponent<HitBox>().hitBoxDuration = attack.hitBoxDuration;
        b.GetComponent<HitBox>().direction = attack.direction;
        b.GetComponent<HitBox>().damage = attack.damage;

        b.GetComponent<HitBox>().status = attack.status;
        b.GetComponent<HitBox>().statusDuration = attack.statusDuration;
        b.GetComponent<HitBox>().cleanseStatus = attack.cleanseStatus;
    }
}

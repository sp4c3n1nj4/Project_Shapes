using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BossFightManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hitboxes;
    [SerializeField]
    private CharacterController con;

    //using a custom Unity Package myde by Textus Games, allows to set and save child classes in the editor
    [SerializeReference, SerializeReferenceButton]
    public List<BossAbilities> bossTimeline;

    private int index = 0;
 
    private void Start()
    {
        //start the first ability in the timeline on script start
        DoAbility(bossTimeline[index]);
    }

    private void EndFight()
    {
        //End the fight if end of list is reached
        throw new NotImplementedException();
    }

    private void DoAbility(BossAbilities ability)
    {
        //excecute function based on the class given and wait the delay
        if (ability.GetType() == typeof(BossMove))
        {
            var a = ability as BossMove;
            BossMoveFunction(a.speed, a.position);
            StartCoroutine(DelayTimer(a.delayTimer));
        }
        else if (ability.GetType() == typeof(BossAttack))
        {
            var a = ability as BossAttack;
            BossAttackFunction(a.boxAttacks);
            StartCoroutine(DelayTimer(a.delayTimer));
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

    private void BossMoveFunction(float speed, Vector3 position)
    {
        var motion = gameObject.transform.position - position;
        con.Move(motion * speed);
    }

    private void BossAttackFunction(HitBoxAttack[] attacks)
    {
        for (int i = 0; i < attacks.Length; i++)
        {
            int h;
            if (attacks[i].hitBoxType == hitBoxType.Cube)
                h = 0;
            else
                h = 1;

            HitBox(h, attacks[i].damage, attacks[i].x, attacks[i].y, attacks[i].time, attacks[i].position, attacks[i].rotation);
        }
    }

    private void HitBox(int index, float damage, float x, float y, float time, Vector3 position, Vector3 rotation)
    {
        //instantiate a cube hitbox and set all its variables
        GameObject b = Instantiate(hitboxes[index], position, Quaternion.Euler(rotation));
        b.transform.localScale = new Vector3(x, b.transform.localScale.y, y);

        b.GetComponent<HitBox>().time = time;
        b.GetComponent<HitBox>().damage = damage;
    }
}

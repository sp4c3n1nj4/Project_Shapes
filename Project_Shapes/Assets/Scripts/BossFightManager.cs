using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BossFightManager : MonoBehaviour
{
    [SerializeField]
    private GameObject HitBoxCube;

    [SerializeReference]
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
            BossAttackFunction(a.position, a.rotation, a.damage, a.size);
            StartCoroutine(DelayTimer(a.delayTimer));
        }
    }

    private IEnumerator DelayTimer(float timer)
    {
        //wait for specified seconds
        yield return new WaitForSeconds(timer);

        //advance index and continue or end fight
        index += 1;
        if (index > bossTimeline.Count)
            EndFight();
        else
            DoAbility(bossTimeline[index]);
    }

    private void BossMoveFunction(float speed, Vector3 position)
    {
        throw new NotImplementedException();
    }

    private void BossAttackFunction(Vector3 position, Vector3 rotation, float damage, float size)
    {
        throw new NotImplementedException();
    }

    private void BoxHitBox(float damage, float x, float y, float time, Vector3 position, Vector3 rotation)
    {
        //instantiate a cube hitbox and set all its variables
        GameObject b = Instantiate(HitBoxCube, position, Quaternion.Euler(rotation));
        b.transform.localScale = new Vector3(x, b.transform.localScale.y, y);

        b.GetComponent<HitBox>().time = time;
        b.GetComponent<HitBox>().damage = damage;
    }
}

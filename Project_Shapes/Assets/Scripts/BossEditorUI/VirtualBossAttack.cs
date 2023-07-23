using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualBossAttack : MonoBehaviour
{
    public int index
    {
        set
        {
            attack = manager.bossTimeline[value] as BossAttack;
        }
    }

    [SerializeField]
    private BossFightManager manager;
    private BossAttack attack;

    public string time
    {
        set
        {
            attack.time = float.Parse(value);
        }
    }

    public string castTime
    {
        set
        {
            attack.boxAttacks[0].castTime = float.Parse(value);
        }
    }

    public int hitBoxType
    {
        set
        {
            switch (value)
            {
                case 0:
                    attack.boxAttacks[0].hitBoxType = HitBoxType.Cube;
                    break;
                case 1:
                    attack.boxAttacks[0].hitBoxType = HitBoxType.Cylinder;
                    break;
                case 2:
                    attack.boxAttacks[0].hitBoxType = HitBoxType.Donut;
                    break;
            }
        }
    }

    public float Yrotation
    {
        set
        {
            attack.boxAttacks[0].Yrotation = value;
        }
    }

    public string Xscale
    {
        set
        {
            attack.boxAttacks[0].scale.x = float.Parse(value);
        }
    }
    public string Yscale
    {
        set
        {
            attack.boxAttacks[0].scale.y = float.Parse(value);
        }
    }


    public int target
    {
        set
        {
            switch (value)
            {
                case 0:
                    attack.boxAttacks[0].target = BossAbilityTarget.none;
                    break;
                case 1:
                    attack.boxAttacks[0].target = BossAbilityTarget.boss;
                    break;
                case 2:
                    attack.boxAttacks[0].target = BossAbilityTarget.player;
                    break;
            }
        }
    }
    public string XOffset
    {
        set
        {
            attack.boxAttacks[0].offSet[0].x = float.Parse(value);
        }
    }
    public string YOffset
    {
        set
        {
            attack.boxAttacks[0].offSet[0].y = float.Parse(value);
        }
    }

    public bool effectDamage
    {
        set
        {
            if (value)
                attack.boxAttacks[0].effect.Add(HitBoxEffect.damage);
            else
                attack.boxAttacks[0].effect.Remove(HitBoxEffect.damage);
        }
    }
    public bool effectContinous
    {
        set
        {
            if (value)
                attack.boxAttacks[0].effect.Add(HitBoxEffect.continous);
            else
                attack.boxAttacks[0].effect.Remove(HitBoxEffect.continous);
        }
    }
    public bool effectKnockback
    {
        set
        {
            if (value)
                attack.boxAttacks[0].effect.Add(HitBoxEffect.knockback);
            else
                attack.boxAttacks[0].effect.Remove(HitBoxEffect.knockback);
        }
    }
    public bool effectTower
    {
        set
        {
            if (value)
                attack.boxAttacks[0].effect.Add(HitBoxEffect.tower);
            else
                attack.boxAttacks[0].effect.Remove(HitBoxEffect.tower);
        }
    }

    public string hitBoxDuration
    {
        set
        {
            attack.boxAttacks[0].hitBoxDuration = float.Parse(value);
        }
    }

    public string Xdirection
    {
        set
        {
            attack.boxAttacks[0].direction.x = float.Parse(value);
        }
    }
    public string Ydirection
    {
        set
        {
            attack.boxAttacks[0].direction.y = float.Parse(value);
        }
    }

    public string damage
    {
        set
        {
            attack.boxAttacks[0].damage = float.Parse(value);
        }
    }

    public bool statusDD
    {
        set
        {
            if (value)
                attack.boxAttacks[0].status.Add(StatusEffect.damageDown);
            else
                attack.boxAttacks[0].status.Remove(StatusEffect.damageDown);
        }
    }
    public bool statusSlow
    {
        set
        {
            if (value)
                attack.boxAttacks[0].status.Add(StatusEffect.slow);
            else
                attack.boxAttacks[0].status.Remove(StatusEffect.slow);
        }
    }
    public bool statusMechanic
    {
        set
        {
            if (value)
                attack.boxAttacks[0].status.Add(StatusEffect.mechanic);
            else
                attack.boxAttacks[0].status.Remove(StatusEffect.mechanic);
        }
    }
    public string statusDuration
    {
        set
        {
            attack.boxAttacks[0].statusDuration = float.Parse(value);
        }
    }
}

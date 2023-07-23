using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualBossMove : MonoBehaviour
{
    public int index 
    {
        set
        {
            move = manager.bossTimeline[value] as BossMove;
        }
    }

    [SerializeField]
    private BossFightManager manager;
    private BossMove move;

    public string time 
    {
        set 
        {          
            move.time = float.Parse(value);
        } 
    }

    public float speed
    {
        set
        {
            move.moveSpeed = value;
        }
    }

    public int target
    {
        set
        {
            switch (value)
            {
                case 0:
                    move.target = BossAbilityTarget.none;
                    break;
                case 1:
                    move.target = BossAbilityTarget.boss;
                    break;
                case 2:
                    move.target = BossAbilityTarget.player;
                    break;
            }
        }
    }

    public string XOffset
    {
        set
        {
            move.offSet[0].x = float.Parse(value);
        }
    }

    public string YOffset
    {
        set
        {
            move.offSet[0].y = float.Parse(value);
        }
    }
}

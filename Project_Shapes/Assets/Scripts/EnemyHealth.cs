using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Entity
{
    [SerializeField]
    private MenuManager manager;

    //display vistory screen on death
    public override void EntityDeath()
    {
        manager.VictoryScreen();
    }

    //update heatlhbar when taking damage
    public override void TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);
        manager.SetBossHealthBar(health / maxHealth);
    }
}

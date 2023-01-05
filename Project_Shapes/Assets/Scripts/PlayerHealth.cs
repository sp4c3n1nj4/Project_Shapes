using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Entity
{
    [SerializeField]
    private MenuManager manager;

    //display defeat screen on death
    public override void EntityDeath()
    {
        manager.DefeatScreen();
    }

    //update heatlhbar when taking damage
    public override void TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);
        manager.SetPlayerHealthBar(health / maxHealth);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Entity
{
    [SerializeField]
    private float slow = 0.6f, damageDown = 0.5f;

    [SerializeField]
    private MenuManager manager;
    [SerializeField]
    private PlayerController controller;
    [SerializeField]
    private PlayerAttackTargeting attacker;

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

    public override void ApplySlow()
    {
        controller.slow = slow;
    }

    public override void ApplyDamageDown()
    {
        attacker.weak = damageDown;
    }
}

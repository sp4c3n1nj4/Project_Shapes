using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatEvent : UnityEvent<float> { }

public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float speed;

    public UnityEvent DeathEvent;
    public FloatEvent DamageEvent;

    private void Start()
    {
        //events for taking damage and dying
        if (DeathEvent == null)
            DeathEvent = new UnityEvent();

        if (DamageEvent == null)
            DamageEvent = new FloatEvent();
        DamageEvent.AddListener(TakeDamage);
    }

    private void TakeDamage(float damage)
    {
        //subtract taken damage from health
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        //check if enemy is dead
        if (health <= 0)
            DeathEvent.Invoke();
    }
}

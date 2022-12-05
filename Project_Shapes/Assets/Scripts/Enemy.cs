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
    public int rarity;
    public float speed;
    public float targetRange;

    public UnityEvent DeathEvent;
    public FloatEvent DamageEvent;

    private void Start()
    {
        if (DeathEvent == null)
            DeathEvent = new UnityEvent();

        if (DamageEvent == null)
            DamageEvent = new FloatEvent();
        DamageEvent.AddListener(TakeDamage);
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    private void Update()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        if (health <= 0)
            DeathEvent.Invoke();
    }
}

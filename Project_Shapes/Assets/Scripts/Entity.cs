using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public virtual void Update()
    {
        //check if health reached 0
        if (health <= 0)
        {
            EntityDeath();
        }
    }

    //base behaviour of on death function
    public virtual void EntityDeath()
    {
        throw new System.NotImplementedException();
    }

    //base function of take damage function
    public virtual void TakeDamage(float _damage)
    {
        health -= _damage;
        health = Mathf.Clamp(health, 0, maxHealth);
    }
}

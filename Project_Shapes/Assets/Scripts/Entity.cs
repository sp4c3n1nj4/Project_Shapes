using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Entity : MonoBehaviour, IEffectable
{
    public float health;
    public float maxHealth;

    private List<StatusEffect> status;

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

    public void ApplyEffect(StatusEffect[] data = null)
    {
        if (data == null)
            return;

        status.AddRange(data);

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] == StatusEffect.slow)
            {
                ApplySlow();
            }

            if (data[i] == StatusEffect.damageDown)
            {
                ApplyDamageDown();
            }
        }
    }

    public virtual void ApplySlow() { }
    public virtual void ApplyDamageDown() { }

    public void RemoveEffect(StatusEffect[] data = null)
    {
        if (data == null)
            return;

        bool inArray(StatusEffect item)
        {
            return data.Contains(item);
        }

        status.RemoveAll(inArray);
    }
}

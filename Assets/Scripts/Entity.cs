using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable{

    public float MaxPower { get; protected set; }
    public float CurrentPower { get; protected set; }

    public bool GettingAbducted { get; set; }

    protected virtual void Update()
    {
        if(CurrentPower <= 0)
        {
            print("dying");
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }

    public virtual void DealDamage(float damage)
    {
        CurrentPower -= damage;
        print("dealing damage");
    }
}

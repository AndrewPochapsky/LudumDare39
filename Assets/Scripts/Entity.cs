using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour{

    public int MaxHealth { get; protected set; }
    public int CurrentHealth { get; protected set; }

    public float MaxPower { get; protected set; }
    public float CurrentPower { get; protected set; }

    


    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}

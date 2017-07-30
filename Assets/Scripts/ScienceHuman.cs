using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScienceHuman : Human {

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        MaxPower = 50;
        CurrentPower = MaxPower;
        Speed = 6f;
    }

    public override void Die()
    {
        GameManager.numSpec++;
        base.Die();
    }
}

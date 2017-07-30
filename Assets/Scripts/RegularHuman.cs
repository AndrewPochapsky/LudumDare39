using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularHuman : Human {



	// Use this for initialization
	protected override void Start () {
        base.Start();

        MaxPower = 8;
        CurrentPower = MaxPower;
        Speed = 5f;
	}

    public override void Die()
    {

        base.Die();
    }

}

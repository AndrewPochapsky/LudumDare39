using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularHuman : Human {

	// Use this for initialization
	protected override void Start () {
        base.Start();

        MaxPower = 5;
        CurrentPower = MaxPower;
        Speed = 2.5f;
	}
	
	
}

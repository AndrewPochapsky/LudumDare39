using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialHuman : Human {

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        MaxPower = 5;
        CurrentPower = MaxPower;
        Speed = 6f;
    }
}

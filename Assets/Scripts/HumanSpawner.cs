using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour {

    private void Start()
    {
        InvokeRepeating("Spawn", 0, 2);
    }

    private void Spawn()
    {
        Instantiate(Resources.Load("RegularHuman"), transform.position, transform.rotation);
    }

   


}

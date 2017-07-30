﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamEnd : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.beam.Abducting)
        {
            Entity entity = collision.GetComponent<Entity>();

            if(entity is RegularHuman)
            {
                player.IncreasePower(entity.MaxPower, 0);
            }
            else if(entity is ArmyHuman)
            {
                player.IncreasePower(entity.MaxPower, 0);
                player.IncreaseDamage(0.5f);
            }
            else if(entity is ScienceHuman)
            {
                player.IncreasePower(entity.MaxPower, entity.MaxPower/2);

            }

           
            entity.Die();
        }
    }

}

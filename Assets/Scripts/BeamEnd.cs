using System.Collections;
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
            player.IncreasePower(entity.MaxPower);
            entity.Die();
        }
    }

}

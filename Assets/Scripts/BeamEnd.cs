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
        print(collision.name);
        if (player.beam.Abducting)
        {
            Human entity = collision.GetComponent<Human>();
            player.IncreasePower(entity.MaxPower);
            entity.Die();
        }
    }

}

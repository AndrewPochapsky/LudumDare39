using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamEnd : MonoBehaviour {

    private Player player;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<Player>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Entity>() && !player.Dead)
        {
            Entity entity = collision.GetComponent<Entity>();

            if(entity is RegularHuman)
            {
                GameManager.numReg++;
                player.IncreasePower(entity.MaxPower, 0);
            }
            else if(entity is ArmyHuman)
            {
                GameManager.numArmy++;
                player.IncreasePower(entity.MaxPower, 0);
                player.IncreaseDamage(0.5f);
            }
            else if(entity is ScienceHuman)
            {
                GameManager.numSpec++;
                player.IncreasePower(entity.MaxPower, entity.MaxPower/2);
            }
            else if(entity is Scrap)
            {
                GameManager.numScrap++;
                player.IncreasePower(entity.MaxPower, maxPower: 0);
                player.IncreaseSpeed(1.5f);
            }

            audioSource.Play();
            entity.Die();
            Destroy(entity.gameObject);
        }
    }

}

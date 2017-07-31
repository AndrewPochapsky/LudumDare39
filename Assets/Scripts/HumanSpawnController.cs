using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawnController : MonoBehaviour {

    int maxNumOfHumans, currNumOfHumans;

    HumanSpawner[] spawners;

	// Use this for initialization
	void Start () {
        spawners = GameObject.FindObjectsOfType<HumanSpawner>();
        maxNumOfHumans = spawners[0].SpawnAmount * spawners.Length;
	}
	
	// Update is called once per frame
	void Update () {
        currNumOfHumans = GameObject.FindObjectsOfType<Human>().Length;

        //If amount of humans gets below starting number then spawn one in 
        //at a random spawner
        if(currNumOfHumans < maxNumOfHumans)
        {
            int randomIndex = Random.Range(0, spawners.Length);
            spawners[randomIndex].Spawn();
            print("spawning");
        }


	}
}

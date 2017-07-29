﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherSpawner : MonoBehaviour {

    bool spawning = false;

    float spawnTime = 15;

    private void Awake()
    {
        Spawn();
    }

    // Use this for initialization 
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.childCount == 0 && !spawning)
        {
            StartCoroutine(SpawnCountDown());               
        }
	}

    void Spawn()
    {
        GameObject obj = Instantiate(Resources.Load("MissileLauncher"), transform.position, transform.rotation)as GameObject;

        obj.transform.SetParent(this.transform);

        spawning = false;
    }

    IEnumerator SpawnCountDown()
    {
        spawning = true;
        yield return new WaitForSeconds(spawnTime);
        Spawn();
    }


}

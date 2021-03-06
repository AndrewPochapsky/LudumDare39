﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour {

    int spawnAmount = 8;



    public int SpawnAmount
    {
        get
        {
            return spawnAmount;
        }
    }

    private void Awake()
    {
        for (int i = 0; i < SpawnAmount; i++)
        {
            Spawn();
        }
    }

    private void Start()
    {

        //InvokeRepeating("Spawn", 0, 2);
    }

    public void Spawn()
    {
        Human.HumanType type = ChooseType();

        GameObject obj = Instantiate(Resources.Load(type+ "Human"), transform.position, transform.rotation) as GameObject;
        obj.transform.SetParent(this.transform);
    }

    private Human.HumanType ChooseType()
    {
        int randomNum = Random.Range(1, 16);
        if (randomNum == 15)
        {
            return Human.HumanType.Science;
        }
        else if(randomNum >= 14)
        {
            return Human.HumanType.Army;
        }
        return Human.HumanType.Regular;
    }

   


}

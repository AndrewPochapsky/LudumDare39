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
        Human.HumanType type = ChooseType();

        Instantiate(Resources.Load(type+ "Human"), transform.position, transform.rotation);
    }

    private Human.HumanType ChooseType()
    {
        int randomNum = Random.Range(1, 11);
        if (randomNum == 10)
        {
            return Human.HumanType.Special;
        }
        else if(randomNum >= 7)
        {
            return Human.HumanType.Army;
        }
        return Human.HumanType.Regular;
    }

   


}

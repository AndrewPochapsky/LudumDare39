using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndUIController : MonoBehaviour {

    public TextMeshProUGUI regText, armyText, scienceText, damageText, powerText;

	// Use this for initialization
	void Start () {
        regText.text = "Regular: " + GameManager.numReg;
        armyText.text = "Army: " + GameManager.numArmy;
        scienceText.text = "Science: " + GameManager.numSpec;

        damageText.text = "Damage: " + GameManager.finalDamage;
        powerText.text = "Max Power: " + GameManager.finalMaxPower;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

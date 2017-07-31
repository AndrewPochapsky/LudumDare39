using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndUIController : MonoBehaviour {

    public TextMeshProUGUI regText, armyText, scienceText, damageText, powerText, speedText, scrapText, killedText;

	// Use this for initialization
	void Start () {
        regText.text = "Regular: " + GameManager.numReg;
        armyText.text = "Army: " + GameManager.numArmy;
        scienceText.text = "Science: " + GameManager.numSpec;
        scrapText.text = "Scrap: " + GameManager.numScrap;

        damageText.text = "Damage: " + GameManager.finalDamage;
        powerText.text = "Max Power: " + GameManager.finalMaxPower;
        speedText.text = "Max Speed: " + GameManager.finalSpeed;
        killedText.text = "Humans Killed: " + GameManager.numKilled;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

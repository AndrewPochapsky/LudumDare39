using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Transform powerBar;

    public TextMeshProUGUI powerText, numRegText, numArmyText, numSpecText;

    Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ManageAbductInfoUI();

        ManagePowerUI();
	}

    private void ManagePowerUI()
    {
        powerText.text = player.CurrentPower.ToString("n2") + "/"+player.MaxPower;
        float value = player.CurrentPower / player.MaxPower;
        powerBar.localScale = new Vector3(value, powerBar.localScale.y, powerBar.localScale.z);
    }

    private void ManageAbductInfoUI()
    {
        numRegText.text = "Regular: "+GameManager.numReg.ToString();
        numArmyText.text = "Army: "+ GameManager.numArmy.ToString();
        numSpecText.text = "Science: "+ GameManager.numSpec.ToString();
    }

}


﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Transform powerBar;

    public TextMeshProUGUI powerText, numRegText, numArmyText, numSpecText, numScrapText;

    public Transform pausePanel, introPanel;

    Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<Player>();
        ManageIntro();

	}
	
	// Update is called once per frame
	void Update ()
    {
        ManageAbductInfoUI();

        ManagePowerUI();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

	}

    private void ManagePowerUI()
    {
        powerText.text = player.CurrentPower.ToString("n2") + "/"+player.MaxPower;
        float value = player.CurrentPower / player.MaxPower;
        powerBar.localScale = new Vector3(value, powerBar.localScale.y, powerBar.localScale.z);
    }

    private void ManageAbductInfoUI()
    {
        numRegText.text = GameManager.numReg.ToString();
        numArmyText.text = GameManager.numArmy.ToString();
        numSpecText.text = GameManager.numSpec.ToString();
        numScrapText.text = GameManager.numScrap.ToString();
    }

    public void PauseGame()
    {
        pausePanel.gameObject.SetActive(!pausePanel.gameObject.activeSelf);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }

    public void ManageIntro()
    {

        introPanel.gameObject.SetActive(!introPanel.gameObject.activeSelf);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }

}


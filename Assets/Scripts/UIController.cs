using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Transform powerBar;

    Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        float value = player.CurrentPower / player.MaxPower;
        powerBar.localScale = new Vector3(value, powerBar.localScale.y, powerBar.localScale.z);
	}
}

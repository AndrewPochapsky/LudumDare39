using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusIndicator : MonoBehaviour {

    public Transform powerBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPower(float current, float max)
    {
        float value = current / max;

        powerBar.localScale = new Vector3(value, powerBar.localScale.y, powerBar.localScale.z);
    }
}

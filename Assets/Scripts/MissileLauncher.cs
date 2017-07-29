using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour, IDamageable {

    private float _maxPower;
    private float _currentPower;

    public StatusIndicator indicator;

    public void DealDamage(float damage)
    {
        _currentPower -= damage;
        indicator.SetPower(_currentPower, _maxPower);
    }

    // Use this for initialization
    void Start () {
        _maxPower = 20;
        _currentPower = _maxPower;
    }
	
	// Update is called once per frame
	void Update () {
		if(_currentPower <= 0)
        {
            Die();
        }
	}

    private void Die()
    {
        Instantiate(Resources.Load("Scrap"), transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

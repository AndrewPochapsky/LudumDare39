using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour, IDamageable {

    private float _maxPower;
    private float _currentPower;

    bool dead = false;

    public AudioClip hitChip, deadClip;

    public StatusIndicator indicator;

    AudioSource audioSource;

    public void DealDamage(float damage)
    {
        _currentPower -= damage;
        indicator.SetPower(_currentPower, _maxPower);
    }

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        _maxPower = 60;
        _currentPower = _maxPower;
    }
	
	// Update is called once per frame
	void Update () {
		if(_currentPower <= 0 && !dead)
        {
            StartCoroutine(Die());
        }
	}



    private IEnumerator Die()
    {
        dead = true;
        Instantiate(Resources.Load("Scrap"), transform.position, transform.rotation);

        
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        GetComponent<BoxCollider2D>().enabled = false;

        audioSource.clip = deadClip;
        audioSource.Play();
        

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Laser>())
        {
            audioSource.clip = hitChip;
            audioSource.Play();
        }
    }

}

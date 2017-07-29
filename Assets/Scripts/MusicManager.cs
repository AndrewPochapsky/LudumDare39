using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    AudioClip startClip, gameClip, endClip;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    private void ChooseClip()
    {
        AudioClip clipToPlay = null;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                clipToPlay = startClip;
                break;

            case "Game":
                clipToPlay = gameClip;
                break;

            case "End":
                clipToPlay = endClip;
                break;    
        }
        audioSource.clip = clipToPlay;
        audioSource.Play();
    }
}

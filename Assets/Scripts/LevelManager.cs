using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Transform panel;
    public Slider slider;
    public TextMeshProUGUI percent;

    

    public void LoadLevel(string level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }

    public void LoadLevelASync(string level)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadAsync(level));

    }
    
    IEnumerator LoadAsync(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        panel.gameObject.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            percent.text = (progress * 100).ToString() + "%";

            yield return null;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }


}

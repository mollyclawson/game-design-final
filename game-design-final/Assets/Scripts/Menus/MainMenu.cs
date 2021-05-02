using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    //public RectTransform loadingPlatform;

    private void Start() {
      PlayerPrefs.SetInt("Health", 3);
    }
    
    public void PlayGame ()
    {
        StartCoroutine(Wait());   
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    
    IEnumerator Wait()
    {
      
      AsyncOperation operation = SceneManager.LoadSceneAsync("LevelTutorial");
      
      loadingScreen.SetActive(true);
      // 
      // Vector2 position = loadingPlatform.anchoredPosition;
      // float positionX = position.x * 10f;
      
      while (!operation.isDone)
      {
        float progress = Mathf.Clamp01(operation.progress/.9f);
        slider.value = progress;
        // Debug.Log(progress);
        // position.x = positionX + (progress * 200f);
        yield return null;
      }
    }
}

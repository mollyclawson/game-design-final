using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
  public GameObject loadingScreen;
  public RectTransform loadingPlatform;
  
  public void LoadLevel (string sceneName)
  {
    StartCoroutine(LoadAsynchronously (sceneName));
  }
  
  IEnumerator LoadAsynchronously (string sceneName)
  {
    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
    
    loadingScreen.SetActive(true);
    
    Vector2 position = loadingPlatform.anchoredPosition;
    float positionX = position.x * 10f;
    
    while (!operation.isDone)
    {
      float progress = Mathf.Clamp01(operation.progress/.9f);
      Debug.Log(progress);
      position.x = positionX * 1f * 0.2f;
      yield return null;
    }
  }
}

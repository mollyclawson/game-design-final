using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public GameObject loadingScreen;
    public RectTransform loadingPlatform;
    
    public void PlayGame ()
    {
        animator.Play("FadeOut");
        StartCoroutine(Wait());   
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    
    IEnumerator Wait()
    {
      yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
      
      AsyncOperation operation = SceneManager.LoadSceneAsync("LevelTutorial");
      
      loadingScreen.SetActive(true);
      
      Vector2 position = loadingPlatform.anchoredPosition;
      float positionX = position.x * 10f;
      
      while (!operation.isDone)
      {
        float progress = Mathf.Clamp01(operation.progress/.9f);
        Debug.Log(progress);
        position.x = positionX + (progress * 200f);
        yield return null;
      }
    }
}

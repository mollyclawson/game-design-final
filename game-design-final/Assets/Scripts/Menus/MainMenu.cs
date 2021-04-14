using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    
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
    
    private IEnumerator Wait()
    {
      yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
      SceneManager.LoadScene("LevelTutorial");
    }
}

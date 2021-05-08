using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalDoor : MonoBehaviour
{
    public bool isOpen = false;
    public GameObject loadingScreen;
    public Slider slider;
    public string nextLevel;
    public Animator animator;
    public Animator transition;

    void Start() {
        // gameObject.GetComponent<Collider2D>().isTrigger = false;
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    void Update() {

        // Only make the door a trigger when all switches are pulled
        if(isOpen == true)
        {
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // StartCoroutine(Wait());
        if(isOpen == true)
        {
            //ADD DOOR SOUND HERE
            animator.SetTrigger("OpenDoor");
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
      yield return new WaitForSeconds(1f);
      transition.SetTrigger("Start");
      yield return new WaitForSeconds(1f);
      SceneManager.LoadScene(nextLevel);
      
      // AsyncOperation operation = SceneManager.LoadSceneAsync(nextLevel);
      // 
      // loadingScreen.SetActive(true);
      // 
      // while (!operation.isDone)
      // {
      //   float progress = Mathf.Clamp01(operation.progress/.9f);
      //   slider.value = progress;
      //   yield return null;
      // }
    }
}

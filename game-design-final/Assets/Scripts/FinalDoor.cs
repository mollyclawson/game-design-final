using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalDoor : MonoBehaviour
{
    public bool isOpen = false;
    
    public Animator animator;

    void Start() {
        gameObject.GetComponent<Collider2D>().isTrigger = false;
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
        // Go to win screen
        animator.Play("FadeOut");
        StartCoroutine(Wait()); 
    }
    
    private IEnumerator Wait()
    {
      yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
      SceneManager.LoadScene("Level1");
    }
}

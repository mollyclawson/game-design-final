using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Transition() {
        StartCoroutine(Animate());
    }

    IEnumerator Animate() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }
}

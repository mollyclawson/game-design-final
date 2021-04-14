﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public Animator animator;
    
    void Start()
    {
        animator.Play("FadeIn");
    }
    
    public void TryAgain ()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}

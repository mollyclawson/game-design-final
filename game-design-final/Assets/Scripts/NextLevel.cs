using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        // Go to next level
        SceneManager.LoadScene("Level2");
    }
}

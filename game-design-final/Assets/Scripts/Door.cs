using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public LevelTransition levelTransition;

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
        levelTransition.Transition();
        SceneManager.LoadScene("TestLevel1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalBarrier : MonoBehaviour
{
    public bool isOpen = false;

    void Start() {
        // gameObject.GetComponent<Collider2D>().isTrigger = false;
        gameObject.GetComponent<Collider2D>().isTrigger = false;
    }

    public void OpenBarrier()
    {
        isOpen = true;
    }

    void Update() {

        // Only make the door a trigger when all switches are pulled
        if(isOpen == true)
        {
            gameObject.active = false;
        }
    }
}

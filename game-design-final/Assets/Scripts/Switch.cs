using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    GameObject switchOn;

    [SerializeField]
    GameObject switchOff;

    public bool isOn = false;
    
    public Animator animator;
    
    private AudioSource sound;

    void Start()
    {
        // sets the switch to off sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = switchOff.GetComponent<SpriteRenderer>().sprite;

	      sound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // If I hit the player...
        if (col.gameObject.tag == "Player") {
            // set switch to on sprite
            gameObject.GetComponent<SpriteRenderer>().sprite = switchOn.GetComponent<SpriteRenderer>().sprite;

            // set isOn to true when triggered
            animator.SetTrigger("SwitchOn");  
            if (!isOn) {
              sound.Play();
            }    
            isOn = true;
             
        }
    }
}

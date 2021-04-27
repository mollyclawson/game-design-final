﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hearts : MonoBehaviour
{
   private int health = 3;
   public int numOfHearts = 3;

   public Image[] hearts;
   public Sprite fullHeart;
   public Sprite emptyHeart;
   private AudioSource sound;
   
   void Start()
   {
       sound = GetComponent<AudioSource>();
   }

   void Update() {

       //make sure health isn't greater than numOfHearts
       if(health > numOfHearts) {
           health = numOfHearts;
       }

       if(health < 0) {
           health = 0;
       }

       if (health <= 0)
        {
            // DIE
            PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("LoseScreen");
        }

       for(int i = 0; i < hearts.Length; i++) {

           //change sprites to empty or full
           if(i < health) {
               hearts[i].sprite = fullHeart;
           } else {
               hearts[i].sprite = emptyHeart;
           }

           if(i < numOfHearts) {
               hearts[i].enabled = true;
           } else {
               hearts[i].enabled = false;
           }
       }
       Debug.Log("Health is " + health);
   }

   public void takeDamage() {
       Debug.Log("Health was" + health);
       health = health - 1;
       if (health != 0)
        {
          sound.Play();
        }
       Debug.Log("Health is now" + health);

   }
}

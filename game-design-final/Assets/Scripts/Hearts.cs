using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
   public int health;
   public int numOfHearts;

   public Image[] hearts;
   public Sprite fullHeart;
   public Sprite emptyHeart;

   void Update() {

       //make sure health isn't greater than numOfHearts
       if(health > numOfHearts) {
           health = numOfHearts;
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
   }

}

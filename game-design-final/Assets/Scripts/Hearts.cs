using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Hearts : MonoBehaviour
{
   private int health = 3;
   public int numOfHearts = 3;

   public Image[] hearts;
   public Sprite fullHeart;
   public Sprite emptyHeart;
   private AudioSource sound;
   public Image vignette;
   
   public Animator animator;

   void Start()
   {
       //COMMENT OUT THIS LINE IF YOU AREN'T STARTING FROM MAIN MENU
       health = PlayerPrefs.GetInt("Health");
       sound = GetComponent<AudioSource>();
       vignette.enabled = false;
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
            animator.SetTrigger("Isdead");
            PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("Health", 3);
            StartCoroutine(Lose());
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
   
   private IEnumerator Lose()
   {
     yield return new WaitForSeconds(2f);
     SceneManager.LoadScene("LoseScreen");
   }

   public void takeDamage() {
       health = health - 1;
       PlayerPrefs.SetInt("Health", health);
       sound.Play();
       vignette.enabled = true;
       StartCoroutine(hurtVignette());
   }

   private IEnumerator hurtVignette()
   {
     yield return new WaitForSeconds(0.1f);
     vignette.enabled = false;
   }

   public void gainHealth(){
       if(health == 3) return;
       health = health + 1;
       Debug.Log("In gainHealth");
       PlayerPrefs.SetInt("Health", health);
   }
}

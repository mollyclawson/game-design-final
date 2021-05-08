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
   public Image vignette;
   
   public Animator animator;
   
   private AudioSource yellSound;
   private AudioSource fallSound;
   
   public PlayerMovement deathbool;
   //public GameObject deathMenu;

   void Start()
   {
       //COMMENT OUT THIS LINE IF YOU AREN'T STARTING FROM MAIN MENU
       health = PlayerPrefs.GetInt("Health");
       vignette.enabled = false;
       GameObject g = GameObject.FindGameObjectWithTag("Player");
       deathbool = g.GetComponent<PlayerMovement>();
       deathbool.isDead = false;
   }
   
     private void Awake()
   	{
   		AudioSource[] sounds = GetComponents<AudioSource>();
   		for ( int i = 0; i < sounds.Length; i++ )
   		{
   			if ( sounds[i].clip.name == "player_yell" ) yellSound = sounds[i];
   			if ( sounds[i].clip.name == "fall_on_ground" ) fallSound = sounds[i];
   		}

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
            deathbool.isDead = true;
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
     //deathMenu.ToggleLoseMenu(); //Doesn't seem to work
     SceneManager.LoadScene("LoseScreen");
   }

   public void takeDamage() {
       health = health - 1;
       PlayerPrefs.SetInt("Health", health);
       yellSound.Play();
       if(health <= 0)
       {
         StartCoroutine(Fall());
       }
       vignette.enabled = true;
       StartCoroutine(hurtVignette());
   }
   
   private IEnumerator Fall()
   {
     yield return new WaitForSeconds(0.2f);
     fallSound.Play();
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

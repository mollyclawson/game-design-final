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
   
   private PlayerMovement deathbool;
   private loseMenu deathMenu;
   private List<GameObject> spikes;

   public AudioClip loseMusic;
   //public MusicManager mm;
   

   void Start()
   {
       //COMMENT OUT THIS LINE IF YOU AREN'T STARTING FROM MAIN MENU
       List<GameObject> spikes = new List<GameObject>();
       List<GameObject> platforms = new List<GameObject>();
       
       health = PlayerPrefs.GetInt("Health");
       vignette.enabled = false;
       
       GameObject g = GameObject.FindGameObjectWithTag("Player");
       deathbool = g.GetComponent<PlayerMovement>();
       deathbool.isDead = false;
       
       foreach(GameObject ObjectFound in GameObject.FindGameObjectsWithTag("Spike"))
       {
         ObjectFound.GetComponent<EnemyPace>().isDead = false;
       }
       
       GameObject l = GameObject.FindGameObjectWithTag("canvas");
       deathMenu = l.GetComponent<loseMenu>();
       deathMenu.loseMusic = loseMusic;
       
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
            //spikebool.isDead = true;
            foreach(GameObject ObjectFound in GameObject.FindGameObjectsWithTag("Spike"))
            {
              ObjectFound.GetComponent<EnemyPace>().isDead = true;
            }
            
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
        //mm.ChangeBGM(loseMusic);
        Time.timeScale = 0f;
        deathMenu.ToggleLoseMenu();
        
     //SceneManager.LoadScene("LoseScreen");
   }

   public void takeDamage() {
       health = health - 1;
       PlayerPrefs.SetInt("Health", health);
       if(health <= 0)
       {
         yellSound.Play();
         StartCoroutine(Fall());
       } else if (health > 0) {
         yellSound.Play();
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

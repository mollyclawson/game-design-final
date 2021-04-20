using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

      public float startHealth = 100;
      private float health;
      //public GameObject deathEffect;
      public Image healthBar;
      public Color healthyColor = new Color(0.3f, 0.8f, 0.3f);
      public Color mediumColor = new Color(0.3f, 0.8f, 0.3f);
      public Color unhealthyColor = new Color(0.8f, 0.3f, 0.3f);

            //temporary time variables:
      public float timeToDamage = 5f;
      private float theTimer;
      public float damageAmt = 10f;
      
      public GameObject loadingScreen;
      public Slider slider;
      public string nextLevel;
      
      // audio stuff
  	private AudioSource hurtSound1;
   	private AudioSource hurtSound2;
   	private AudioSource dieSound;

      private void Start () {
            health = startHealth;
            theTimer= timeToDamage;
            
            // stupid hack to sort game sounds
		AudioSource[] sounds = GetComponents<AudioSource>();
		for ( int i = 0; i < sounds.Length; i++ )
		{
			if ( sounds[i].clip.name == "enemy_hit_1" ) hurtSound1 = sounds[i];
			if ( sounds[i].clip.name == "enemy_hit_2" ) hurtSound2 = sounds[i];
			if ( sounds[i].clip.name == "player_yell" ) dieSound = sounds[i];
		}
      }

// this timer is just to test damage. Comment-out when no longer needed
      void FixedUpdate () {
            // theTimer -= Time.deltaTime;
            // if (theTimer <= 0) {
            //       TakeDamage(damageAmt);
            //       theTimer = timeToDamage;
            // }
      }


      public void SetColor(Color newColor){
            healthBar.GetComponent<Image>().color = newColor;
      }

      public void TakeDamage (float amount){
            health -= amount;
            healthBar.fillAmount = health / startHealth;
            //turn red at low health:
            if (health < 30f){
                  if ((health * 100f) % 3 <= 0){
                        SetColor(Color.white);
                        Die();
                  }
                  else {
                        SetColor(unhealthyColor);
                  }
            }
            else {
                  if(health > 50f){
                        SetColor(healthyColor);
                  } else {
                        SetColor(mediumColor);
                  }
                  
            }
            
            if (Random.Range(0,1) > 0.5)
            {
           	 hurtSound1.pitch = Random.Range( 0.8f, 1.2f );
           	 hurtSound1.Play();
            }
            else
            {
                 hurtSound2.pitch = Random.Range( 0.8f, 1.2f );
           	 hurtSound2.Play();
            } 
      }



      public void Die(){
            Debug.Log("You Died So Much");  
            StartCoroutine(Wait()); 
        // death stuff. change scene? how about a particle effect?
        //Vector3 objPos = this.transform.position
        //Instantiate(deathEffect, objPos, Quaternion.identity) as GameObject;
        //SceneManager.LoadScene ("Scene_lose");
    }
    
    private IEnumerator Wait()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);


      AsyncOperation operation = SceneManager.LoadSceneAsync(nextLevel);
      loadingScreen.SetActive(true);

      while (!operation.isDone)
      {
        float progress = Mathf.Clamp01(operation.progress/.9f);
        slider.value = progress;
        yield return null;
      }
    }
}

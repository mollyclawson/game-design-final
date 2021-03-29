using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

   public int damage = 1;
   public float speed = 10f;
   private Transform playerTrans;
   private Vector2 target;
   public GameObject hitEffectAnim;

   //if bullet hits a collider, play explosion animation, then destroy effect and bullet
   void OnTriggerEnter2D(Collider2D other){
      // if (other.gameObject.tag != "Enemy") {
      //    if (other.gameObject.tag == "Player"){
      //    GameObject healthBar = GameObject.FindWithTag("healthBar");
      //    if(healthBar != null){
      //       healthBar = healthBar.GetComponent();
      //       healthBar.takeDamage(damage);
      //       Debug.log("Collided");
      //    }
      //   }
      // }
    }
}

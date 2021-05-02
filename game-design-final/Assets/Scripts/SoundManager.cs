using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private AudioSource icicleSound;
    // Start is called before the first frame update
    void Awake()
    {
        AudioSource[] sounds = GetComponents<AudioSource>();
		for ( int i = 0; i < sounds.Length; i++ )
		{
			if ( sounds[i].clip.name == "ice_break" ) icicleSound = sounds[i];
		}
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void playIceSound(){
        Debug.Log("In the play ice sound func");
        if(icicleSound != null) {
            icicleSound.Play();
        } else {
            Debug.Log("Sound is null");
        }

    }
}

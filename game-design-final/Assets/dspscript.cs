using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dspscript : MonoBehaviour
{

	public AudioLowPassFilter lp;
	public AudioHighPassFilter hp;
	public PlayerMovement player;
	public float hpval = 1000.0f;
	public float lpval = 3000.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    		lp.cutoffFrequency = Mathf.Lerp(lpval, 20000.0f, player.timeScale());    		
    		hp.cutoffFrequency = Mathf.Lerp(hpval, 10.0f, player.timeScale());
    }
}

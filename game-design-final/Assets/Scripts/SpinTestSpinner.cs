using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpinTestSpinner : MonoBehaviour
{
	public float speed = 10f;
	// private float amt = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
    	transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}

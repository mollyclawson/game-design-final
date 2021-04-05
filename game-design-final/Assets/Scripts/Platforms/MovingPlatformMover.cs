using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformMover : MonoBehaviour
{
	
	public float speed = 1f;
	public float extent = 1f;
	private float sx;	
	
    // Start is called before the first frame update
    void Start()
    {
        sx = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 temp = transform.position;
    	temp.x = sx + Mathf.Sin( Time.time * speed ) * extent;
    	transform.position = temp; 
        
    }
}

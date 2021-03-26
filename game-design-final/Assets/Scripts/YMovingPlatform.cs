using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YMovingPlatform : MonoBehaviour
{

	public float speed = 1f;
	public float extent = 1f;
	private float sy;

    // Start is called before the first frame update
    void Start()
    {
        sy = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
    	Vector3 temp = transform.position;
    	temp.y = sy + Mathf.Sin( Time.time * speed ) * extent;
    	transform.position = temp;

    }
}

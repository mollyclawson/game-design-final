using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigfanscript : MonoBehaviour
{
	public float speed = 10f;
	public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        // player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime * player.timeScale());
    }
}

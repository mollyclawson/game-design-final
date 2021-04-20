using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{

	private AudioSource music;
	
	private void Awake()
	{
		music = GetComponent<AudioSource>();
	}
}

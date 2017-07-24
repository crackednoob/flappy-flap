using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	private AudioSource audio;

	void Start()
	{
		audio = GetComponent<AudioSource> ();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") ) {
			GameController.instance.BirdScored ();
			audio.Play ();
		}
	}
}

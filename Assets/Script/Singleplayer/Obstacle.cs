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
		if (other.GetComponent<Bird> () != null || other.GetComponent<BirdMultiplayer>() !=null ) {
			GameController.instance.BirdScored ();
			if(GameObject.FindGameObjectWithTag("Network"))
				MultiplayerController.instance.BirdScored ();
			audio.Play ();
		}
	}
}

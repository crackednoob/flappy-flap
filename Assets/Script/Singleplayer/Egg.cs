using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {

	private Vector2 reset = new Vector2(-100f, -100f);
	private AudioSource audio;

	void Start()
	{
		audio = GetComponent<AudioSource> ();
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.CompareTag("Player") == true && GameController.instance.gameOver == false) {
			GameController.instance.BirdScored ();
			transform.position = reset;
			audio.Play ();
		}else if (coll.CompareTag("Obstacle")) {
			transform.position = new Vector2 (transform.position.x + 2f, transform.position.y);
		}
	}
}

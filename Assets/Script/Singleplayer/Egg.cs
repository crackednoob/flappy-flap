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
		if (coll.GetComponent<Bird> () != null || coll.GetComponent<BirdMultiplayer>() != null  && GameController.instance.gameOver == false) {
			GameController.instance.BirdScored ();
			this.transform.position = reset;
			audio.Play ();
		}
	}

	private void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.GetComponent<Obstacle> () != null) {
			this.transform.position = new Vector2 (transform.position.x + 2f, transform.position.y);
		}
	}
}

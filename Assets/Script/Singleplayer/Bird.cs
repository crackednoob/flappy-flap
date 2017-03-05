using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	private bool isDead;
	private Rigidbody2D rb2d;
	private Animator anim;
	private AudioSource sound;

	public float upForce = 200f;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sound = GetComponent<AudioSource> ();
		PlayerPrefs.SetInt ("Dead", 0);
		PlayerPrefs.SetInt ("Pause", 0);
	}

	void Update () {
		if (isDead == false && PlayerPrefs.GetInt("Pause") == 0) {
			if(Input.GetButtonDown("Fire1")){
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (new Vector2(0, upForce));
				anim.SetTrigger ("Flap");
				sound.Play ();
			}
		}
		
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Obstacle" || coll.gameObject.tag == "Ground") {
			isDead = true;
			anim.SetTrigger ("Die");
			GameController.instance.BirdDead ();
		}
	}
}

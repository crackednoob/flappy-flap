using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BirdMultiplayer : NetworkBehaviour {

	private bool isDead;
	private Rigidbody2D rb2d;
	private Animator anim;
	private AudioSource sound;
	private ScrollingObject scroll;

	public float upForce = 200f;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sound = GetComponent<AudioSource> ();
		scroll = GetComponent<ScrollingObject> ();
		PlayerPrefs.SetInt ("Dead", 0);
		PlayerPrefs.SetInt ("Pause", 0);
	}

	void Update () {
		if (!isLocalPlayer)
			return;
		if (isDead == false && PlayerPrefs.GetInt("Pause") == 0) {
			if(Input.GetButtonDown("Fire1")){
				CmdFlap ();
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (new Vector2 (0, upForce));
			}
		}
	}

	[Command]
	public void CmdFlap()
	{
		
		RpcFlap ();
		sound.Play ();
	}

	[ClientRpc]
	public void RpcFlap()
	{
		anim.SetTrigger ("Flap");
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (isDead == true)
			return;
		
		if (coll.gameObject.tag == "Obstacle" || coll.gameObject.tag == "Ground") {
			anim.SetTrigger ("Die");
			MultiplayerController.instance.BirdDead ();
			isDead = true;
			scroll.enabled = true;
		}
	}
}

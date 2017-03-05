using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	private Rigidbody2D rb2D;

	void Start()
	{
		rb2D = GetComponent <Rigidbody2D> ();
		rb2D.velocity = new Vector2 (GameController.instance.scrollSpeed, 0);
	}

	void Update()
	{
		if (GameController.instance.gameOver == true) {
			rb2D.velocity = Vector2.zero;
		}
	}
}

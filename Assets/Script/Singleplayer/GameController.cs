using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public GameObject gameOverText;
	public bool gameOver = false;
	public float scrollSpeed = -1.7f;
	public Text scoreText;
	public Text highScoreText;

	private GameObject multiplayer;
	private int highScore;
	private int score = 0;

	void Awake()
	{
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy (gameObject);
			Debug.Log ("ancru");
		}
	}

	void Start()
	{
		multiplayer = GameObject.FindGameObjectWithTag ("Network");
		highScore = PlayerPrefs.GetInt ("HighScore");
		highScoreText.text = "High Score : " + highScore.ToString ();
	}

	void Update()
	{
		if (gameOver == true && Input.GetButtonDown ("Fire1")) {
			PlayerPrefs.SetInt ("Dead", 0);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			MultiplayerManager.manager.StopHost ();
		}
	}

	public void BirdScored()
	{
		if (gameOver)
			return;
		score++;
		scoreText.text = "Score : " + score.ToString ();
		if (highScore < score && multiplayer == null)
			highScoreText.text = "High Score : " + score.ToString ();
	}

	public void BirdDead()
	{
		if (score > highScore)
			highScore = score;
		PlayerPrefs.SetInt ("HighScore", highScore);
		PlayerPrefs.SetInt ("Dead", 1);
		gameOverText.SetActive (true);
		gameOver = true;
		if(multiplayer == null)
			highScoreText.text = "High Score : " + highScore.ToString ();
	}
}

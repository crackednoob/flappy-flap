using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;

public class MultiplayerController : NetworkBehaviour {

	public static MultiplayerController instance;
	public Text[] score;
	private float numberOfPlayer = -1;
	private int playerScorePosition;
	private int playerCurrentScore = 0;
	private int firstPosition;
	private int secondPosition;
	private int thirdPosition;
	private int fourthPosition;

	private int[] playerScore;

	[SyncVar]
	private float numberOfDead;

	[SyncVar]
	private bool allDead = false;

	void Awake()
	{
		instance = this;
	}

	void Update()
	{
		CountDead ();
		if (allDead) {
			GameController.instance.BirdDead ();
		}
	}

	public void BirdScored()
	{
		playerCurrentScore++;
		CmdBirdScore (playerCurrentScore,playerScorePosition);
	}

	[Command]
	public void CmdBirdScore(int score, int target)
	{
		if (playerScore [0] == null || target == 1) {
			playerScore [0] = score;
			playerScorePosition = 1;
			CmdScoreBoard ();

			return;
		}
		if (playerScore [1] == null || target == 2) {
			playerScore [1] = score;
			playerScorePosition = 2;

			CmdScoreBoard ();
			return;
		}
		if (playerScore [2] == null || target == 3) {
			playerScorePosition = 3;
			playerScore [2] = score;

			CmdScoreBoard ();
			return;
		}
		if (playerScore [3] == null || target == 4) {
			playerScore [3] = score;
			playerScorePosition = 4;

			CmdScoreBoard ();
			return;
		}

		RpcPlayerScore (playerScorePosition);

	}

	[Command]
	public void CmdScoreBoard()
	{
		for (int i = 1; i < numberOfPlayer; i++) {
			if (playerScore [i] > firstPosition)
				firstPosition = playerScore [i];
			if (playerScore[i] < firstPosition && playerScore [i] > thirdPosition)
				secondPosition = playerScore [i];
			if (playerScore[i] < secondPosition && playerScore [i] > fourthPosition)
				thirdPosition = playerScore [i];
			else
				fourthPosition = playerScore [i];

		}

		RpcScoreBoardUpdate ();
	}

	[ClientRpc]
	private void RpcScoreBoardUpdate()
	{
		
	}

	[ClientRpc]
	public void RpcPlayerScore(int target)
	{
		target += 1;
		score [target].text = "P" + target.ToString () + " : " + playerCurrentScore.ToString();
	}

	public void BirdDead()
	{
		numberOfDead++;
	}

	void CountDead()
	{
		if (!isServer)
			return;
		
		numberOfPlayer = GameObject.FindGameObjectsWithTag ("Player").Length;

		if (numberOfDead == numberOfPlayer && numberOfPlayer != 0) {
			GameController.instance.BirdDead ();
			allDead = true;

		}
		
	}

}

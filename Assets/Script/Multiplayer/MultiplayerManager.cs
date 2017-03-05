using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine;

public class MultiplayerManager : NetworkBehaviour {

	public static NetworkManager manager;
	public AnimationClip fadeAlphaAnimationClip;

	void Start()
	{
		manager = GetComponent<NetworkManager> ();
	}
		

	public void StartHost()
	{
		manager.StartHost ();

	}

	public void StartClient()
	{
		manager.StartClient ();
	}

	public void StopHost()
	{
		manager.StopHost();
	}
}

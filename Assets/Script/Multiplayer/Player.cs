using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class ToggleEvent : UnityEvent<bool>{}

public class Player : NetworkBehaviour
{
	[SerializeField] ToggleEvent onToggleShared;
	[SerializeField] ToggleEvent onToggleLocal;
	[SerializeField] ToggleEvent onToggleRemote;

	void Start()
	{
		EnablePlayer ();
		PlayerPrefs.SetInt ("Dead", 0);
		PlayerPrefs.SetInt ("Pause", 0);
	}

	void Update()
	{

	}

	void DisablePlayer()
	{
		onToggleShared.Invoke (false);

		if(isLocalPlayer)
			onToggleLocal.Invoke(false);
		else
			onToggleRemote.Invoke(false);
	}

	void EnablePlayer()
	{
		onToggleShared.Invoke (true);

		if(isLocalPlayer)
			onToggleLocal.Invoke(true);
		else
			onToggleRemote.Invoke(true);
	}
}
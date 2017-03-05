using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	public static DontDestroy dontDestroyInstance;


	void Awake()
	{
		
		//Causes UI object not to be destroyed when loading a new scene. If you want it to be destroyed, destroy it manually via script.
		DontDestroyOnLoad(this.gameObject);
		PlayerPrefs.SetInt ("Dead", 0);
		if (dontDestroyInstance == null)
			dontDestroyInstance = this;
		else if(dontDestroyInstance !=this)
			Destroy (gameObject);
	}

	

}

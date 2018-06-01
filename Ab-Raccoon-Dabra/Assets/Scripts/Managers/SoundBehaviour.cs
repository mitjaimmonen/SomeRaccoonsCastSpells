using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundBehaviour : MonoBehaviour {

	[FMODUnity.EventRef] public string backgroundMusic;
	FMOD.Studio.EventInstance musicEI;

	GameObject target;
	Player player;

	float timer;
	void Awake()
	{
		if (GameObject.FindGameObjectsWithTag("SoundManager").Length > 1)
		{
			Destroy(this.gameObject);
		}

		DontDestroyOnLoad(this);
		musicEI = FMODUnity.RuntimeManager.CreateInstance(backgroundMusic);
		musicEI.start();
 		FMODUnity.RuntimeManager.AttachInstanceToGameObject(musicEI, GetComponent<Transform>(), GetComponent<Rigidbody>());

		SceneManager.sceneLoaded += LoadScene;
	}
	void OnDisable() {
		SceneManager.sceneLoaded -= LoadScene;
	}

	void LoadScene(Scene scene, LoadSceneMode mode)
	{
		Debug.Log("Scene Loaded.");
		musicEI.setParameterValue("isGame", SceneManager.GetActiveScene().buildIndex == 1 ? 1 : 0);
		musicEI.setParameterValue("Master", 0.8f);
		musicEI.setParameterValue("isAlive", 1);

		FMOD.Studio.PLAYBACK_STATE playbackState;
		musicEI.getPlaybackState(out playbackState);
		if (playbackState != FMOD.Studio.PLAYBACK_STATE.PLAYING || SceneManager.GetActiveScene().buildIndex == 0)
			musicEI.start();

	}
		
	void Update()
	{
		musicEI.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));

		if (timer < Time.time - 0.033f) //Update 30 tps
		{
			timer = Time.time;
			if (!target)
				target = GameObject.FindGameObjectWithTag("Player");
			if (!target)
				target = GameObject.Find("Main Camera");
			if (target)
				transform.position = target.transform.position;
			if (!player)
			{
				GameObject temp = GameObject.FindGameObjectWithTag("Player");
				if (temp)
					player = temp.GetComponentInChildren<Player>();
			}
			musicEI.setParameterValue("isGame", SceneManager.GetActiveScene().buildIndex == 1 ? 1 : 0);
			musicEI.setParameterValue("Master", 0.8f);
			if (player)
				musicEI.setParameterValue("isAlive", player.IsAlive ? 1 : 0);

		}
	}
}

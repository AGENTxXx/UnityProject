using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class startClass : MonoBehaviour {

	public GameObject audioFile;

	public static GameObject instance;

	void Awake()
	{
		if (!instance) {
			instance = Instantiate(audioFile) as GameObject;
			DontDestroyOnLoad (instance);

			int soundStatus = PlayerPrefs.GetInt("sound");

			if (soundStatus == 0)
			{
				instance.GetComponent<AudioSource>().Stop();
				GameObject.Find("sound").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sound_off");
				globalClass.soundOn = false;
			}

		}

	}

	public void oneGamerBtnClick() {
		globalClass.countPlayers = 1;
		SceneManager.LoadScene ("selectField");
	}

	public void twoGamersBtnClick() {
		globalClass.countPlayers = 2;
		SceneManager.LoadScene ("selectField");
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameClass : MonoBehaviour {

	private bool isMobile = true;
	private gridFormatClass gf;

	public GameObject cardObject;
	public GameObject grid;

	public Text score;
	public Text firstScoreGamer;
	public Text secondScoreGamer;

	public bool isMobileRun
	{
		get { return isMobile; }
	}

	void OnGUI()
	{
		if (globalClass.countPlayers == 1) {
			score.text = "Очки: " + globalClass.firstScoreGamer.ToString (); //change text value.	
		} else {
			firstScoreGamer.text = "Игрок 1: " + globalClass.firstScoreGamer.ToString (); //change text value.	
			secondScoreGamer.text = "Игрок 2: " + globalClass.secondScoreGamer.ToString (); //change text value.	
		}

	}

	// Use this for initialization
	void Start () {
		globalClass.correct = 0;
		globalClass.firstScoreGamer = 0;
		globalClass.secondScoreGamer = 0;

		globalClass.isFirst = true;
		globalClass.activeGamer = 1;

		globalClass.cardFirst = null;
		globalClass.cardSecond = null;

		if (globalClass.countPlayers == 1) {
			GameObject.Find ("Canvas/Panel/score").SetActive (true);
		} else {
			GameObject.Find ("Canvas/Panel/scoreFirstGamer").SetActive (true);
			GameObject.Find ("Canvas/Panel/scoreSecondGamer").SetActive (true);
		}
		//float screenHeightInUnits = Camera.main.orthographicSize * 2;
		//Debug.Log (screenHeightInUnits);
		//float screenWidthInUnits = screenHeightInUnits * Screen.width/ Screen.height;
		//Debug.Log (screenWidthInUnits);

		#if UNITY_EDITOR
		isMobile = false;
		#endif

		#if UNITY_IPHONE
		isMobile = true;
		#endif

		#if UNITY_ANDROID
		isMobile = true;
		#endif

		#if UNITY_STANDALONE_OSX
		isMobile = false;
		#endif

		#if UNITY_STANDALONE_WIN
		isMobile = false;
		#endif


		GameObject go = new GameObject();
		go.AddComponent<gridFormatClass> ();
		gf = go.GetComponent<gridFormatClass>();
		gf.initGrid (cardObject, grid);

	}

	public void goToFirstScene() {
		SceneManager.LoadScene ("startScene");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

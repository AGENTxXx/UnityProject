using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameClass : MonoBehaviour {

	private bool isMobile = true;
	private gridFormatClass gf;

	public GameObject cardObject;
	public GameObject grid;

	public bool isMobileRun
	{
		get { return isMobile; }
	}

	void OnGUI()
	{

		//GUIContent content = new GUIContent();

		//GUIStyle contentStyleLabel = new GUIStyle("label");
	}

	// Use this for initialization
	void Start () {
		float screenHeightInUnits = Camera.main.orthographicSize * 2;
		Debug.Log (screenHeightInUnits);
		float screenWidthInUnits = screenHeightInUnits * Screen.width/ Screen.height;
		Debug.Log (screenWidthInUnits);

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

		gf = new gridFormatClass ();
		gf.initGrid (cardObject, grid);

	}

	public void goToFirstScene() {
		SceneManager.LoadScene ("startScene");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

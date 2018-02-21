using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cardScript : MonoBehaviour {

	public int imgId = 0;

	private int firstImgId, secondImgId;
	private static int multiplyForFirstGamer = 1, multiplyForSecondGamer = 1;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Touch t in Input.touches)
		{
			if (t.phase == TouchPhase.Began)
			{
				Vector3 point = new Vector3(t.position.x, t.position.y, 0);
				Ray ray = Camera.main.ViewportPointToRay(point);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					hit.collider.SendMessage("OnMouseDown", null, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	void OnMouseDown()
	{
		if (globalClass.isFirst) {
			hideCards ();
			globalClass.cardFirst = gameObject;
			globalClass.cardFirst.GetComponent<SpriteRenderer> ().enabled = false;
			globalClass.cardFirst.GetComponent<BoxCollider2D> ().enabled = false;
			globalClass.isFirst = !globalClass.isFirst;
		} else {
			globalClass.cardSecond = gameObject;
			globalClass.cardSecond.GetComponent<SpriteRenderer> ().enabled = false;
			globalClass.cardSecond.GetComponent<BoxCollider2D> ().enabled = false;

			firstImgId = globalClass.cardFirst.GetComponent<cardScript> ().imgId;
			secondImgId = globalClass.cardSecond.GetComponent<cardScript> ().imgId;

			globalClass.isFirst = true;
			//Debug.Log ("firstImgId " + firstImgId );
			//Debug.Log ("firstImgId " + secondImgId );
			if (firstImgId == secondImgId) {

				if (globalClass.countPlayers == 2) {
					if (globalClass.activeGamer == 1) {
						globalClass.firstScoreGamer += multiplyForFirstGamer;
						multiplyForFirstGamer *= 2; 
						globalClass.activeGamer = 2;
					} else {
						globalClass.secondScoreGamer += multiplyForSecondGamer;
						multiplyForSecondGamer *= 2; 
						globalClass.activeGamer = 1;
					}
				} else {
					globalClass.firstScoreGamer += multiplyForFirstGamer;
					multiplyForFirstGamer *= 2;
				}
				globalClass.cardFirst = null;
				globalClass.cardSecond = null;

				globalClass.correct++;
				if (globalClass.correct == globalClass.maxCorrect) {
					Invoke ("getEndScene", 0.5f);
					return;
				}
			} else {

				if (globalClass.activeGamer == 1) {
					multiplyForFirstGamer = 1;
					if (globalClass.countPlayers == 2) {
						globalClass.activeGamer = 2;
					}
				} else {
					multiplyForSecondGamer = 1;
					globalClass.activeGamer = 1;
				}

				Invoke("hideCards", 0.5f);
			}
		}
	}

	void getEndScene()
	{
		/*
		Destroy(globalClass.cardFirst);
		Destroy(globalClass.cardSecond);
		*/
		SceneManager.LoadScene ("gameOverScene");
	}

	void hideCards()
	{
		if (globalClass.cardFirst && globalClass.cardSecond) {
			globalClass.cardFirst.GetComponent<SpriteRenderer> ().enabled = true;
			globalClass.cardSecond.GetComponent<SpriteRenderer> ().enabled = true;
			globalClass.cardFirst.GetComponent<BoxCollider2D> ().enabled = true;
			globalClass.cardSecond.GetComponent<BoxCollider2D> ().enabled = true;
			globalClass.cardFirst = null;
			globalClass.cardSecond = null;
		}
	}
}

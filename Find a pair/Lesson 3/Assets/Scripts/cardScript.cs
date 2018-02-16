using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cardScript : MonoBehaviour {

	public int imgId = 0;
	private static bool isFirst = true;
	private int firstImgId, secondImgId;
	private int multiplyForFirstGamer = 1, multiplyForSecondGamer = 1;
	private int activeGamer = 1;


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
		if (isFirst) {
			globalClass.cardFirst = gameObject;
			globalClass.cardFirst.GetComponent<SpriteRenderer> ().enabled = false;
			globalClass.cardFirst.GetComponent<BoxCollider2D> ().enabled = false;
			isFirst = !isFirst;
		} else {
			globalClass.cardSecond = gameObject;
			globalClass.cardSecond.GetComponent<SpriteRenderer> ().enabled = false;
			globalClass.cardSecond.GetComponent<BoxCollider2D> ().enabled = false;

			firstImgId = globalClass.cardFirst.GetComponent<cardScript> ().imgId;
			secondImgId = globalClass.cardSecond.GetComponent<cardScript> ().imgId;

			isFirst = true;
			Debug.Log ("firstImgId " + firstImgId );
			Debug.Log ("firstImgId " + secondImgId );
			if (firstImgId == secondImgId) {
				globalClass.correct++;
				if (globalClass.correct == globalClass.maxCorrect) {
					Invoke ("getEndScene", 0.5f);
					return;
				}

				if (globalClass.countPlayers == 2) {
					if (activeGamer == 1) {
						globalClass.firstScoreGamer += multiplyForFirstGamer;
						multiplyForFirstGamer *= 2; 
						activeGamer = 2;
					} else {
						globalClass.secondScoreGamer += multiplyForSecondGamer;
						multiplyForSecondGamer *= 2; 
						activeGamer = 1;
					}
				} else {
					globalClass.firstScoreGamer += multiplyForFirstGamer;
					multiplyForFirstGamer *= 2;
				}
			} else {

				if (activeGamer == 1) {
					multiplyForFirstGamer = 1;
					activeGamer = 2;
				} else {
					multiplyForSecondGamer = 1;
					activeGamer = 1;
				}

				Invoke("hideCards", 0.5f);
			}
		}
	}

	void getEndScene()
	{
		Destroy(globalClass.cardFirst);
		Destroy(globalClass.cardSecond);
		SceneManager.LoadScene ("gameOverScene");
	}

	void hideCards()
	{
			globalClass.cardFirst.GetComponent<SpriteRenderer> ().enabled = true;
			globalClass.cardSecond.GetComponent<SpriteRenderer> ().enabled = true;
			globalClass.cardFirst.GetComponent<BoxCollider2D> ().enabled = true;
			globalClass.cardSecond.GetComponent<BoxCollider2D> ().enabled = true;
	}
}

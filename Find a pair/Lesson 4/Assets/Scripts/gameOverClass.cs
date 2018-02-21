using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class gameOverClass : MonoBehaviour {

	public GameObject onePanel;
	public GameObject twoPanel;

	public void Start() {
		
		if (globalClass.countPlayers == 1) {
			//GameObject.Find ("OneGamerPanel").gameObject.SetActive(true);

			int recordScore = PlayerPrefs.GetInt("record");

			if (globalClass.firstScoreGamer > recordScore) {
				PlayerPrefs.SetInt("record", globalClass.firstScoreGamer);
				recordScore = globalClass.firstScoreGamer;
			}

			onePanel.SetActive(true);
			Text record = GameObject.Find ("Record").GetComponent<Text> ();
			Text score = GameObject.Find ("Score").GetComponent<Text> ();

			record.text = "Рекорд \r\n" + recordScore;
			score.text = "Очки \r\n" + globalClass.firstScoreGamer;
		} else {
			twoPanel.SetActive(true);
			Text gamerOne = GameObject.Find ("GamerOne").GetComponent<Text> ();
			Text gamerTwo = GameObject.Find ("GamerTwo").GetComponent<Text> ();
			Text win = GameObject.Find ("Win").GetComponent<Text> ();

			gamerOne.text = "Игрок 1 \r\n" + globalClass.firstScoreGamer;
			gamerTwo.text = "Игрок 2 \r\n" + globalClass.secondScoreGamer;
			if (globalClass.firstScoreGamer == globalClass.secondScoreGamer) {
				win.text = "У игроков\r\n" + "ничья";	
			} else {
				if (globalClass.firstScoreGamer > globalClass.secondScoreGamer) {
					win.text = "Победил\r\n" + "игрок 1";
				} else {
					win.text = "Победил\r\n" + "игрок 2";
				}
			}

		}
		
	}


	public void goToFirstScene() {
		SceneManager.LoadScene ("startScene");
	}

	public void restartGame() {
		SceneManager.LoadScene ("gameScene");
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class gameOverClass : MonoBehaviour {

	public GameObject onePanel;
	public GameObject twoPanel;

	public void Start() {
		
		globalClass.countPlayers = 1;
		if (globalClass.countPlayers == 1) {
			//GameObject.Find ("OneGamerPanel").gameObject.SetActive(true);
			onePanel.SetActive(true);
			Text record = GameObject.Find ("Record").GetComponent<Text> ();
			Text score = GameObject.Find ("Score").GetComponent<Text> ();

			record.text = "Рекорд \r\n" + "12";
			score.text = "Очки \r\n" + "10";
		} else {
			twoPanel.SetActive(true);
			Text gamerOne = GameObject.Find ("GamerOne").GetComponent<Text> ();
			Text gamerTwo = GameObject.Find ("GamerTwo").GetComponent<Text> ();
			Text win = GameObject.Find ("Win").GetComponent<Text> ();

			gamerOne.text = "Игрок 1 \r\n" + "1";
			gamerTwo.text = "Игрок 1 \r\n" + "2";
			win.text = "Победил\r\n" + "Игрок 2";
		}
		
	}


	public void goToFirstScene() {
		SceneManager.LoadScene ("startScene");
	}

	public void restartGame() {
		SceneManager.LoadScene ("gameScene");
	}

}

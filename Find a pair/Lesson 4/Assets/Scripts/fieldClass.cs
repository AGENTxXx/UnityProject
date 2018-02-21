using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class fieldClass : MonoBehaviour {

	public void setGrid4x4() {
		globalClass.gridHeight = 4;
		globalClass.gridWidth = 4;
		SceneManager.LoadScene ("gameScene");
	}

	public void setGrid4x5() {
		globalClass.gridHeight = 4;
		globalClass.gridWidth = 5;
		SceneManager.LoadScene ("gameScene");
	}

	public void setGrid5x6() {
		globalClass.gridHeight = 5;
		globalClass.gridWidth = 6;
		SceneManager.LoadScene ("gameScene");
	}

	public void setGrid5x8() {
		globalClass.gridHeight = 5;
		globalClass.gridWidth = 8;
		SceneManager.LoadScene ("gameScene");
	}

}

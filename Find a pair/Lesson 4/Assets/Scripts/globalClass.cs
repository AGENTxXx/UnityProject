using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class globalClass {
	public static bool soundOn = true;
	public static int countPlayers = 1;
	public static int gridHeight = 4;
	public static int gridWidth = 4;

	public static GameObject obj1;
	public static GameObject obj2;

	public static bool isFirst = true;
	public static int activeGamer = 1;

	public static int correct = 0;
	public static int maxCorrect = 0;

	public static int firstScoreGamer = 0;
	public static int secondScoreGamer = 0;

	public static int screenH = Screen.height;
	public static int screenW = Screen.width;

	public static GameObject cardFirst
	{
		get { return obj1; }
		set { obj1 = value; }
	}

	public static GameObject cardSecond
	{
		get { return obj2; }
		set { obj2 = value; }
	}

	public static Vector3 getTopLeftPosition(Camera camera) {

		float minX = camera.GetComponent<RectTransform> ().position.x + camera.GetComponent<RectTransform>().rect.xMin;
		float maxY = camera.GetComponent<RectTransform>().position.y + camera.GetComponent<RectTransform>().rect.yMax;
		float z = camera.GetComponent<RectTransform>().position.z;

		/*
		float minX = Camera.main.GetComponent<RectTransform> ().position.x + Camera.main.GetComponent<RectTransform>().rect.xMin;
		float maxY = Camera.main.GetComponent<RectTransform>().position.y + Camera.main.GetComponent<RectTransform>().rect.yMax;
		float z = Camera.main.GetComponent<RectTransform>().position.z;
		*/
		return new Vector3(minX, maxY, z);
	}


	public static Vector3 getTopLeftPosition2()
	{
		float camHalfHeight = Camera.main.orthographicSize;
		float camHalfWidth = Camera.main.aspect * camHalfHeight;

		Bounds bounds = GameObject.Find("Main Camera").GetComponent<SpriteRenderer>().bounds;

		//Bounds bounds = GetComponent<SpriteRenderer>().bounds;

		// Set a new vector to the top left of the scene 
		Vector3 topLeftPosition = new Vector3(-camHalfWidth, camHalfHeight, 0) + Camera.main.transform.position;

		// Offset it by the size of the object 
		topLeftPosition += new Vector3(bounds.size.x / 2, -bounds.size.y / 2, 0);

		return topLeftPosition;
	}
}

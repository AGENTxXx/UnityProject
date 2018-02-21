using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridFormatClass : MonoBehaviour {

	private int[,] gridArr; //Храним ид карточек
	private float middleCountW; //среднее количество карточек по x
	private float middleCountH; //среднее количество карточек по н

	private float cardSize;
	private float cardShiftX, cardShiftY; //получаем верхний нижний угол сетки карточек
	private float shift = 0.05f; //Небольшой сдвиг, чтобы карточки не были впритык

	private GameObject childImg;

	public void initGrid(GameObject gameObj, GameObject panel) {
		
		cardSize = gameObj.GetComponent<BoxCollider2D> ().size.x;
		//Debug.Log ("size" + cardSize);
		middleCountW = globalClass.gridWidth / 2f;
		middleCountH = globalClass.gridHeight / 2f;

		cardShiftX = -middleCountW * cardSize*0.9f - middleCountH * shift;
		cardShiftY = middleCountH * cardSize*0.9f - middleCountH * shift;

		globalClass.maxCorrect = globalClass.gridHeight * globalClass.gridWidth / 2;

		Sprite[] gameSprites;
		gameSprites = Resources.LoadAll<Sprite>("newCards");
		gridArr = null;
		gridArr = new int[globalClass.gridWidth, globalClass.gridHeight];
		int imgId = Random.Range (0, 19);
		int num = 0;

		//Формируем массив с номерами карточек
		for (int i = 0; i < globalClass.gridWidth; i++)
		{
			for (int j = 0; j < globalClass.gridHeight; j++)
			{
				gridArr[i, j] = imgId;
				num++;
				if (num % 2 == 0)
				{
					imgId = Random.Range(0, 19);
				}
			}
		}

		mix (gridArr);

		for (int i = 0; i < globalClass.gridWidth; i++) {
			for (int j = 0; j < globalClass.gridHeight; j++) {
				gameObj.GetComponent<cardScript>().imgId = gridArr[i, j];
				gameObj.transform.localScale = new Vector3(0.9f, 0.9f, 1);

				childImg = gameObj.transform.Find ("img").gameObject;
				childImg.GetComponent<SpriteRenderer>().sprite = gameSprites[gridArr[i, j]];
				Transform clone = Instantiate(gameObj.transform, new Vector3(cardShiftX + i * 1.2f*0.9f+(i*shift), cardShiftY - j * 1.2f*0.9f-(j*shift), 0), Quaternion.identity) as Transform;
				clone.SetParent (panel.transform, false);
			}
		}
	}

	//Перемешиваем карточки
	static void mix(int[,] srcArray)
	{
		for (var i = 0; i < srcArray.Length * 10; i++)
		{
			int r1 = Random.Range(0, srcArray.GetLength(0)),
			r2 = Random.Range(0, srcArray.GetLength(0)),
			c1 = Random.Range(0, srcArray.GetLength(1)),
			c2 = Random.Range(0, srcArray.GetLength(1));
			int temp = srcArray[r1, c1];
			srcArray[r1, c1] = srcArray[r2, c2];
			srcArray[r2, c2] = temp;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

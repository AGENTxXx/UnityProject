using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundClass : MonoBehaviour {
	
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
					//hit.transform.name
					hit.collider.SendMessage("OnMouseDown", null, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	void OnMouseDown()
	{
		if (globalClass.soundOn)
		{
			GameObject.Find("sound").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sound_off");
			startClass.instance.GetComponent<AudioSource>().Stop();
		}
		else
		{
			GameObject.Find("sound").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sound_on");
			startClass.instance.GetComponent<AudioSource>().Play();
		}
		globalClass.soundOn = !globalClass.soundOn;

		PlayerPrefs.SetInt("sound", System.Convert.ToInt16(globalClass.soundOn));
	}
}

using UnityEngine;
using CnControls;
using System.Collections;

public class characterControl : MonoBehaviour {

	// Use this for initialization

    Vector3 position;
	void Start ()
	{
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        position = new Vector3(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"), 0f);

	    transform.position += position*Time.deltaTime*5;

	    if (position.x < 0)
	    {
	        transform.rotation = Quaternion.Euler(0, 180, 0);
	    }
	    else
	    {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

	    if (CnInputManager.GetButtonUp("Jump"))
	    {
	        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,5f),ForceMode2D.Impulse);
	    }
	}
}

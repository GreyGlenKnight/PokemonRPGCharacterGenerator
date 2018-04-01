using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCursor : MonoBehaviour {
	Vector3 CursorBall;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 CursorBall = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = (CursorBall);

	}
}

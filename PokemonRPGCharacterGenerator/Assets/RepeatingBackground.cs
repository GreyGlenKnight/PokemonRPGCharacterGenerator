using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class RepeatingBackground : MonoBehaviour 
{
Rigidbody2D rb2d;
Vector3 Origin;

	void Awake()


	{
	rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = Vector2.one;
	Vector3 Origin = new Vector3(0f,0f,0f);

	InvokeRepeating ("respawn", 1.13f, 1.13f);
	}


private void respawn()

	{

		transform.position = Origin;

			//Destroy(this);
			//Instantiate(this);

	}
}



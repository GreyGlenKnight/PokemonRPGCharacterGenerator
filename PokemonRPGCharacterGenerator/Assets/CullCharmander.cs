using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullCharmander : MonoBehaviour 
{

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}
	private void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.GetComponent<NewCursor>() == null)
		{
		Destroy (collision.gameObject);
//		Debug.Log ("triggered!");
	}
	}

}


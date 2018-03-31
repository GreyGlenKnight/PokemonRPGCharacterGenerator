using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class PokeballSpawner : MonoBehaviour
{			
	public GameObject PortraitObject;
	public GameObject Pokedoll;
	public Sprite Charmander;
	public Rigidbody2D CharCol;
	public Canvas BGCanvas;
	public Vector3 MousePosition;
	List<GameObject> Population = new List<GameObject> ();
//	BoxCollider2D Background;

	public void Spawn ()

	{
		//PortraitObject = this;

		//PortraitObject = new GameObject();

		Instantiate (Pokedoll, MousePosition, Quaternion.identity);
		Population.Add (Pokedoll);
		Debug.Log (MousePosition);
		Debug.Log (Population.Count);
		var i = Population.Count;
		if(i>6)

		{ 
			Destroy(Population[i]);
			i--;
			Debug.Log ("Culling...");

		}
		}
		//GameObject Pokedoll = GameObject.Instantiate (PortraitObject, Vector3(transform.position.x,transform.position.y, transform.position.z));// as GameObject;
		//Pokedoll.transform.parent = BGCanvas.transform;
		//Instantiate(box,Vector3 (Input.mousePosition.x,0,Input.mousePosition.z), Quaternion.identity); } 
		//PortraitObject = GameObject.Instantiate (PortraitObject, Input.mousePosition, transform.rotation) as GameObject;
	
		//PortraitObject.AddComponent<Rigidbody2D>();




	void Update()
	{

		if (Input.GetMouseButtonUp (0)) 
		{
			MousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f);
			Spawn ();
		
				//DestroyObject (Pokedoll);

			}

		}
	
}
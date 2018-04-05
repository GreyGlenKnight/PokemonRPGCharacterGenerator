using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PokeballSpawner : MonoBehaviour
{			
	private int NumberSpawned;
	public GameObject PortraitObject;
	public GameObject Pokedoll;
	public Sprite Charmander;
	public Rigidbody2D CharCol;
	public Canvas BGCanvas;
	public Vector3 MousePosition;
	public Vector3 NewPos;
	public float RandomSize;

	GameObject[] Population = new GameObject[151];
	//	BoxCollider2D Background;

	public void Spawn ()
	{
		//PortraitObject = this;
		Vector3 NewPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		NewPos.z = 1;
		if (Population [NumberSpawned % 151] != null) 
		{
			Destroy (Population [NumberSpawned % 151]);
		}
		RandomSize = UnityEngine.Random.Range(.2f, .4f);
		Population [NumberSpawned % 151] = Instantiate (Pokedoll, NewPos, Quaternion.identity);
		Pokedoll.transform.localScale = new Vector3(RandomSize, RandomSize, RandomSize);
		NumberSpawned++;
	}

	void Update()
	{

		if (Input.GetMouseButtonUp (0)) 
		{
			MousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f);
		
			//audioSource.pitch = rng;

			Spawn ();
		
				//DestroyObject (Pokedoll);

			}

		}
	
}


//GameObject newPokedoll = Instantiate (Pokedoll, NewPos, Quaternion.identity);
//	Population.Add (newPokedoll);
//GameObject Before Instantiate new Pokedoll =  //(Pokedoll, MousePosition, Quaternion.identity);
//Population.Add (new Pokedoll);
//	Debug.Log (MousePosition);
//	Debug.Log (Population.Count);
//	var i = Population.Count;
//if(i>64)
//{
//	Destroy(Population[i-1]);

//	Population.RemoveAt(Population.Count - 1);
//		i--;
//		Debug.Log ("Culling...");

//	}



//GameObject Pokedoll = GameObject.Instantiate (PortraitObject, Vector3(transform.position.x,transform.position.y, transform.position.z));// as GameObject;
//Pokedoll.transform.parent = BGCanvas.transform;
//Instantiate(box,Vector3 (Input.mousePosition.x,0,Input.mousePosition.z), Quaternion.identity); } 
//PortraitObject = GameObject.Instantiate (PortraitObject, Input.mousePosition, transform.rotation) as GameObject;

//PortraitObject.AddComponent<Rigidbody2D>();




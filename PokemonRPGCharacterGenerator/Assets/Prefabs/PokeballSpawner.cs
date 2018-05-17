using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;


public class PokeballSpawner : MonoBehaviour
{			
	private int NumberSpawned;
	public GameObject PortraitObject;
	public GameObject Pokedoll;
//	public Sprite Charmander;
	public Rigidbody2D CharCol;
//	public Canvas BGCanvas;
	public Vector3 MousePosition;
	public Vector3 NewPos;
	public float RandomSize;
	public static int SongPos = 0;
	GameObject[] Population = new GameObject[151];

	static List <float> SongPitches = new List <float> ();
	public float D  = 1.33482036104f;
	public float A 	= 1f;
	public float A2	= 2f;
	public float G	= 1.78174539625f;
	public float FSharp	= 1.68174862312f;
	public float E	= 1.49827644455f;
	public float CSharp	= 1.25990633062f;
	public float B	= 2.2448323043f;

	void Awake ()
	{

		SongPitches.Add (D);
		SongPitches.Add (A);
		SongPitches.Add (D);
		SongPitches.Add (A2);
		SongPitches.Add (G);
		SongPitches.Add (FSharp);
		SongPitches.Add (E);
		SongPitches.Add (CSharp);

		SongPitches.Add (CSharp);
		SongPitches.Add (A);
		SongPitches.Add (CSharp);
		SongPitches.Add (FSharp);
		SongPitches.Add (E);
		SongPitches.Add (CSharp);
		SongPitches.Add (D);
		SongPitches.Add (FSharp);

		SongPitches.Add (D);
		SongPitches.Add (A);
		SongPitches.Add (D);
		SongPitches.Add (A2);
		SongPitches.Add (G);
		SongPitches.Add (FSharp);
		SongPitches.Add (E);
		SongPitches.Add (CSharp);

		SongPitches.Add (CSharp);
		SongPitches.Add (A);
		SongPitches.Add (CSharp);
		SongPitches.Add (FSharp);
		SongPitches.Add (E);
		SongPitches.Add (CSharp);
		SongPitches.Add (D);
		SongPitches.Add (FSharp);

		SongPitches.Add (FSharp);
		SongPitches.Add (A2);
		SongPitches.Add (G);
		SongPitches.Add (A2);
		SongPitches.Add (G);
		SongPitches.Add (FSharp);
		SongPitches.Add (E);

		SongPitches.Add (CSharp);
		SongPitches.Add (E);
		SongPitches.Add (FSharp);
		SongPitches.Add (G);
		SongPitches.Add (FSharp);
		SongPitches.Add (E);
		SongPitches.Add (D);

		SongPitches.Add (FSharp);
		SongPitches.Add (A2);
		SongPitches.Add (G);
		SongPitches.Add (FSharp);
		SongPitches.Add (G);
		SongPitches.Add (A2);
		SongPitches.Add (B);

		SongPitches.Add (A2);
		SongPitches.Add (G);
		SongPitches.Add (FSharp);
		SongPitches.Add (G);
		SongPitches.Add (FSharp);
		SongPitches.Add (G);
		SongPitches.Add (FSharp);
		SongPitches.Add (E);
		SongPitches.Add (D);
	}

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
		RandomSize = (SongPitches.ElementAt (SongPos) * .25f);
		Population [NumberSpawned % 151] = Instantiate (Pokedoll, NewPos, Quaternion.identity);
		Pokedoll.transform.localScale = new Vector3(RandomSize, RandomSize, RandomSize);
		NumberSpawned++;
		SongPos++;
		if (SongPos == SongPitches.Count) 
		{
			SongPos = 0;
		}
	}

	void Update()
	{

		if (Input.GetMouseButtonUp (0)) 
		{
			MousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f);
		
			Spawn ();
		
			}

		}
	
}
	
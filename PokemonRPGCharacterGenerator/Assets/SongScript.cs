using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SongScript : MonoBehaviour 
{

	public float D  = 1.33482036104f;
	public float A 	= 1f;
	public float A2	= 2f;
	public float G	= 1.78174539625f;
	public float FSharp	= 1.68174862312f;
	public float E	= 1.49827644455f;
	public float CSharp	= 1.25990633062f;
	public float B	= 2.2448323043f;
	public AudioSource Note;
	public AudioClip SongClip;
	public static int SongPos = 0;

	static List <float> SongPitches = new List <float> ();

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

	public void SongCry()
	{
		
		Note.pitch = SongPitches.ElementAt(SongPos);
		Note.clip = SongClip;
		Note.Play ();
		SongPos++;

		if (SongPos == SongPitches.Count) 
		{
			SongPos = 0;
		}
	}

	void Start () 
	{
		SongCry ();	
	}

}

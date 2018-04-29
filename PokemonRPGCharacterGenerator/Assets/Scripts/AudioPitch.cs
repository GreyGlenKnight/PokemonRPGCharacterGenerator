using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class AudioPitch : MonoBehaviour 


{
	public float LowRange;
	public float HighRange;
	public float randomindex;
	public AudioSource Cry;
	public AudioClip CryClip;

	public void RandomCry()
	{
		randomindex = UnityEngine.Random.Range(LowRange, HighRange);
		//Debug.Log (randomindex);
		Cry.pitch = randomindex;
		Cry.clip = CryClip;
		Cry.Play ();
	}

	void Awake () 
	{
		RandomCry ();	
	}

}

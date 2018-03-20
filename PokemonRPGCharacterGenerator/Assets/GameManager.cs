using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public static class ListExtensions


{	private static System.Random rng = new System.Random();  

	public static void Shuffle<T>(this IList<T> list)  
	{  
		int n = list.Count;  
		while (n > 1) {  
			n--;  
			int k = rng.Next(n + 1);  
			T value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}}

public class GameManager : MonoBehaviour 
	

{

	public TreeManager[] AllTrees;

	public static GameManager instance = null;

	TextWriter testfile; 
	public void CallTreeRoll()
	{for (int i = 0; i < AllTrees.Length; i++) 
		{AllTrees [i].RollOnTree ();
		}
	}
	void Awake()

	//Awake is always called before any Start functions
	//Function doesn't return anything

	{
		if (instance == null)
		{instance = this;}

		//I think this means if a file is newly created, it will automatically name or define it as THIS.  

		else  if (instance != this)
		{Destroy (gameObject);}
		DontDestroyOnLoad(gameObject);

	}

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public static class ListExtensions
//This shuffle function can be applied to lists, as in an extension of existing functions?
//Treemanager refers to bonuses.shuffle, with bonuses being a list of ints.

{	private static System.Random rng = new System.Random();  

	//This makes it a little easier to use rng.next to keep making new numbers.

	public static void Shuffle<T>(this IList<T> list)  

	//We use T as a generic, single type. We can call Shuffle now, as a function defined here.
	//When we call shuffle on a list, we declare the list such as bonuses.shuffle, and 'this' refers to that instance.
	//Using IList<T> rather than List<T> allows the code to be more flexible. 
	//It can replace the implementation with any collection that implements IList<T> without breaking any calling code.
	{  
		int n = list.Count;  

		//We assign an integer N with the value of the length of the list. This is dynamic so we select from a smaller range as we go.
		//Shuffle works this way rather than keeping the starting range.

		while (n > 1) 
			
			//Process of elimination leaves only one value for the last item.
			//the following scope only applies to the list when it has multiple items.
			//int n will be 1 when it's last, thus negating the rest of the function.
			//While should mean that this function automatically repeats until N == 1.
		{  
			n--;  
			//The -- operator decrements N by 1. Because it comes after N, it refers to the value after N is decremented.
			//This doesn't happen if N is <= 1. After the semicolon, N is reduced in value for the rest of the function.

			int k = rng.Next(n + 1);  

			//Assigns int K as a new random integer, with a max of N+1. Upper bound is exclusive, so the max is N after --.
			T value = list[k]; 

			//T value is the index of the list, it's the thing that's in K position on the list. This is assigned Value.

			list[k] = list[n];  

			//N is the list.count so it takes the K position on the list, swaps it with the higher list count,
			//since list count is always highest and outside the range of the rng.

			list[n] = value;  

			//
			//All these assignments are necessary because the while parameter makes this repeat.
		}  
	}}

public class GameManager : MonoBehaviour 

{

	public TreeManager[] AllTrees;

	public static GameManager instance = null;

	TextWriter testfile; 
	public int XP;
	public Text XPText;
	public string CurrentXP;
	public bool CanRoll = true;
	public bool CanChoose = false;

	public void AddXP()
		
	{
		if (XP < 50) 
		{
			XP++;
		}
	//	string XPText = XP.ToString ();
	}
	public void SpendXP()
	{
		if (XP < 1) 
		{
			return;
		}
		if (CanRoll == false) 
		{
			XP--;
			CanRoll = true;
			//CanChoose = false;

		}

	}



	public void CallTreeRoll()
	{
		if (CanRoll == false) 
		{
			return;
		}
		if (XP < 1) 
		{
			return;
		} 

			for (int i = 0; i < AllTrees.Length; i++) 
			{
				AllTrees [i].RollOnTree ();

			}
		CanChoose = true;

		CanRoll = false;
		
	}
	void Awake()

	//Awake is always called before any Start functions
	//Void Function doesn't return anything

	{
		CanRoll = true;
	

		if (instance == null)
		{instance = this;}

		//I think this means if a file is newly created, it will automatically name or define it as THIS.  

		else  if (instance != this)
		{Destroy (gameObject);}
		DontDestroyOnLoad(gameObject);



	}
	void Update ()
	{
		CurrentXP = XP.ToString ();
		XPText.text = CurrentXP;
	}

}

﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public static class ListExtensions

{	private static System.Random rng = new System.Random();  

	public static void Shuffle<T>(this IList<T> list)  

	{  
		int n = list.Count;  

		while (n > 1) 
			
		{  
			n--;  

			int k = rng.Next(n + 1);  

			T value = list[k]; 

			list[k] = list[n];  


			list[n] = value;  

		}  
	}
}

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
	public PokeSheetSceneManager _PokeSheetSceneManager;
	public PokeSheetTreeManager _PokeSheetTreeManager;
	//public GameObject PokeSheetTreeManager;

	public void AddXP()
		
	{
		if (XP < 50) 
		{
			XP++;
		}
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

		}

	}

	public void SwitchToTree()
	{
		_PokeSheetSceneManager.gameObject.SetActive (false);
		_PokeSheetTreeManager.gameObject.SetActive (true);
		//Debug.Log ("Tree");

	}

	public void SwitchToSheet()
	{
		_PokeSheetTreeManager.gameObject.SetActive (false);
		_PokeSheetSceneManager.gameObject.SetActive (true);
		//Debug.Log ("Sheet");
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

	{
		CanRoll = true;
	

		if (instance == null)
		{instance = this;}
			
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

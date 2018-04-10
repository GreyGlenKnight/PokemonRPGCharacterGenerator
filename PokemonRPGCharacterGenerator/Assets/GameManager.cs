using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;


public static class ListExtensions

{	
	private static System.Random rng = new System.Random();  
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

public enum SelectionState
{
	Roll,
	Select
}

public class GameManager : MonoBehaviour 

{

	public TreeManager[] AllTrees;
	public List <TreeManager> TreesToRoll = new List <TreeManager> ();
	public static GameManager instance = null;
	public static int XP;
	public Text XPText;
	public string CurrentXP;
	public PokeSheetSceneManager _PokeSheetSceneManager;
	public PokeSheetTreeManager _PokeSheetTreeManager;
	public Toggle AutoSelectToggle;
	public static List <int> GainedBonuses = new List <int> ();
	public static List <int> DeadTrees = new List <int> ();
	public static List <int> ActiveTrees = new List <int> ();



	public void AddXP()
		
	{
		if (XP < 100) 
		{
			XP++;
		}
	}

	public bool SpendXP()
	{
		
		if (XP < 1) 
		{
			return false;
		}
		if (_SelectionState == SelectionState.Roll) 
		{
			XP--;
			_SelectionState = SelectionState.Select;
			return true;
		}
		return false;
	}

	public void SwitchToTree()
	{
		_PokeSheetSceneManager.gameObject.SetActive (false);
		_PokeSheetTreeManager.gameObject.SetActive (true);
	}

	public void SwitchToSheet()
	{
		_PokeSheetTreeManager.gameObject.SetActive (false);
		_PokeSheetSceneManager.gameObject.SetActive (true);

	}
		
	public void CallTreeRoll()
	{
		if (SpendXP () == false) 
		{
			return;
		}
		TreesToRoll = AllTrees.ToList();
//		Debug.Log (TreesToRoll.Count);
//
//		if (DeadTrees.Count > 0) 
//		{
//			int i = DeadTrees [0];
//			Debug.Log (i);
//			TreesToRoll.RemoveAt (i);
//			Debug.Log (TreesToRoll.Count);
//			DeadTrees.RemoveAt (0);
//		}

		for (int i = 0; i < TreesToRoll.Count; i++) 
			{
			
			TreesToRoll[i].RollOnTree ();

			}
	}

	public SelectionState _SelectionState = SelectionState.Roll;

	void Awake()

	{
		if (instance == null)
		{instance = this;}
			
		else  if (instance != this)
		{Destroy (gameObject);}
		DontDestroyOnLoad(gameObject);
//		ActiveTrees = AllTrees.ToList();
//		Debug.Log (ActiveTrees.Count);
	}

	void Update ()
	{
		if (XP < 0)
		{XP = 0;}
		CurrentXP = XP.ToString ();
		XPText.text = CurrentXP;

	}

}

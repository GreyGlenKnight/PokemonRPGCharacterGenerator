using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;


public class TreeManager : MonoBehaviour 
{
	
	List<int> Bonuses = new List<int> ();
	public Toggle[] options = new Toggle[12];
	public Text Tree_text;
//	public static bool CanSelect = false;
	//public bool AutoSelectOn = false;
	public int intrandnumber1;
	public static List <int> IRN1List = new List <int> ();
	public bool IsTreeFull = false;
	public int OnCount;

//	public TreeManager _Trees = new Tree [4];

	public void RollOnTree()

	{
		RollTheList (Bonuses, options, Tree_text);
	}


	public void SelectMe()
	{
//		Debug.Log ("SelectMe");

		if (GameManager.instance._SelectionState == SelectionState.Roll) 
		{
			return;
		}

//		int OnCount = options.Where(n => n.isOn == true).Count();
//
//		if (OnCount == options.Length)      
//		{
//			IsTreeFull = true;    
//			Debug.Log ("Tree is Full");
//		}
//
//
//		if (IsTreeFull == true) 
//		{
//			GameManager.XP++;
//			return;
//		}
//
//		if (IsTreeFull == false) 
//		{
			intrandnumber1 = Bonuses [0];
			Bonuses.RemoveAt (0);
			options [intrandnumber1].isOn = true;
			IRN1List.Clear ();
			GameManager.instance._SelectionState = SelectionState.Roll;
//		}
	}

	public void ResetBonuses ()
	{ 
		for (int i = 0; i < 12; i++) 
		{
			Bonuses.Add (i);
//			options [i].isOn = false;
		}
		Bonuses.Shuffle ();

	}

	public void RollTheList (List <int> LBonus, Toggle[] Loptions, Text LText)
	{
		if (Bonuses.Count > 0)
		{
		Debug.Log (Bonuses.Count);	
		Bonuses.Shuffle ();
		}

		int intrandnumber1 = LBonus [0] + 1;

		if (!options [intrandnumber1 -1].isOn == true)
		{	
			IRN1List.Add (intrandnumber1);
		}
		String randomnumber1 = intrandnumber1.ToString ();
		LText.text = randomnumber1;
	}



	public void Awake()
	{
		ResetBonuses ();
	}
}
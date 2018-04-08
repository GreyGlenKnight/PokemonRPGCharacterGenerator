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
	public int intrandnumber1;
	public static List <int> IRN1List = new List <int> ();
	public bool IsTreeFull = false;

	public void RollOnTree()

	{
		RollTheList (Bonuses, options, Tree_text);
	}

	public void SelectMe()
	{

		if (GameManager.instance._SelectionState == SelectionState.Roll) 
		{
			return;
		}

//		if (IsTreeFull == true) 
//		{
//			Debug.Log ("TREEFULL");
//			//Instantiate new tree?
		//			return;}


		if (Bonuses.Count > 0) 
		{
			intrandnumber1 = Bonuses [0];
			Debug.Log (Bonuses.Count);
			Bonuses.RemoveAt (0);
			options [intrandnumber1].isOn = true;
			GameManager.GainedBonuses.Add (intrandnumber1);
		}

//		if (options [11].isOn == true) 
//		{
//			IsTreeFull = true;
//		}

			IRN1List.Clear ();
			GameManager.instance._SelectionState = SelectionState.Roll;
	}



	public void ResetBonuses ()
	{ 
		for (int i = 0; i < 12; i++) 
		{
			Bonuses.Add (i);
		}
		Bonuses.Shuffle ();

	}

	public void RollTheList (List <int> LBonus, Toggle[] Loptions, Text LText)
	{
		if (LBonus.Count == 0) 
		{
			Debug.Log ("LBONUS 0");
//			GameManager.XP++;
			return;
		}
		if (LBonus.Count > 0)
		{
		Bonuses.Shuffle ();
		}	

		int intrandnumber1 = LBonus [0] + 1;
		if (options [intrandnumber1 -1].isOn == false)
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
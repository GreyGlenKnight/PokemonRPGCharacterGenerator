using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


public class TreeManager : MonoBehaviour 
{
	
	List<int> Bonuses = new List<int> ();
	public Toggle[] options = new Toggle[12];
	public Text Tree_text;
//	public static bool CanSelect = false;
	//public bool AutoSelectOn = false;
	public int intrandnumber1;
//	static List <int> IRN1List = new List <int> ();

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

			intrandnumber1 = Bonuses [0];
			Bonuses.RemoveAt (0);
			options [intrandnumber1].isOn = true;
//		IRN1List.Clear();
		GameManager.instance._SelectionState = SelectionState.Roll;
				Debug.Log ("SelectMe");

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
			ResetBonuses (); 
		}

		Bonuses.Shuffle ();
//		GameManager.instance._SelectionState = SelectionState.Select;
		int intrandnumber1 = LBonus [0] +1;
//		IRN1List.Add (intrandnumber1);
		String randomnumber1 = intrandnumber1.ToString ();
		LText.text = randomnumber1;

	}



	public void Awake()
	{
		ResetBonuses ();
	}
}

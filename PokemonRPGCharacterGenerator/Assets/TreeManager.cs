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
	public static bool CanSelect = false;
	public void RollOnTree()


	{
		RollTheList (Bonuses, options, Tree_text);
	}
	public void SelectMe()

	{
		Debug.Log ("SelectMe");

		if (! GameManager.instance.CanChoose)		
		{
			Debug.Log ("False");

			return;
		}

			if (CanSelect == false) 
			{
				return;
			}

			int intrandnumber1 = Bonuses [0];
			Bonuses.RemoveAt (0);
			options [intrandnumber1].isOn = true;
			CanSelect = false;
		Debug.Log ("Got CanSelect");

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
		if (LBonus.Count == 0) {
			ResetBonuses (); 

		}



		Bonuses.Shuffle ();
		CanSelect = true;
		int intrandnumber1 = LBonus [0] +1;

		String randomnumber1 = intrandnumber1.ToString ();

		LText.text = randomnumber1;

	}
	public void Awake()
	{
		CanSelect = false;
		ResetBonuses ();
	}
}

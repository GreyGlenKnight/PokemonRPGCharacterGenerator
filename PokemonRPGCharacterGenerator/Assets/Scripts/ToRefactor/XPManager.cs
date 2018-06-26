using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class XPManager : MonoBehaviour 
{
	public static int XP
	{		
		get {return GameManager.instance.CurrentPokemon.XP;}
	}

	public Text XPText;
	public string CurrentXP;


		public void AddXP()
		{
			if (XP < 100) 
			{
			GameManager.instance.CurrentPokemon.XP++;
			GameManager.instance.CurrentPokemon.XP++;
			}
		}

		public static bool SpendXP ()
		{

			if (XP < 2) 
			{
				return false;
			}
		if (GameManager.instance._SelectionState == SelectionState.Roll) 
			{
			GameManager.instance.CurrentPokemon.XP--;
			GameManager.instance.CurrentPokemon.XP--;
			GameManager.instance._SelectionState = SelectionState.Select;
				return true;
			}
			return false;
		}
		
	void Update () 

	{
		if (XP < 0)
		{GameManager.instance.CurrentPokemon.XP = 0;}
		CurrentXP = XP.ToString ();
		XPText.text = CurrentXP;
	}
}

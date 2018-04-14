using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class XPManager : MonoBehaviour 
{

	// Use this for initialization
	public static int XP;
	public Text XPText;
	public string CurrentXP;


		public void AddXP()
		{
			if (XP < 100) 
			{
				XP++;
			}
		}
		public static bool SpendXP()
		{

			if (XP < 1) 
			{
				return false;
			}
		if (GameManager.instance._SelectionState == SelectionState.Roll) 
			{
				XP--;
			GameManager.instance._SelectionState = SelectionState.Select;
				return true;
			}
			return false;
		}


	void Update () 

	{
		if (XP < 0)
		{XP = 0;}
		CurrentXP = XP.ToString ();
		XPText.text = CurrentXP;

		
	}
}

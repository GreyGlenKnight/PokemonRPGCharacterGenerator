using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTrees : MonoBehaviour 
{
//	public List <SkillTreeDisplay> _SkillTreeDisplayList = new List <SkillTreeDisplay> (4);
	public const int NUMBER_OF_TREES = 4;
	public BonusAtIndex [] TreeRolls = new BonusAtIndex [NUMBER_OF_TREES];
	public SkillTree [] ActiveRolls = new SkillTree[NUMBER_OF_TREES];
	public bool TreeFull;
	public List <int> TempRolls = new List <int> ();

	public void OnAutoSelectClick ()

	{
		for (int i = 0; i < NUMBER_OF_TREES; i++) 
		{
			TreeRolls [i] = ActiveRolls [i].GetCurrentSelectedBonus ();
			//GetCurrentSelectedBonus returns RemainingBonuses [0]
		}

		for (int i = 0; i < NUMBER_OF_TREES; i++) 
		{
			if (TreeRolls [i] == BonusAtIndex.StatUp) 
			{
				TempRolls.Add (i);
			}
		}
		if (TempRolls.Count > 0) 
		{
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].OnSelected ();
			TempRolls.Clear ();

			{
				return;}
		}



		for (int i = 0; i < NUMBER_OF_TREES; i++) 
		{
			if (TreeRolls [i] <= BonusAtIndex.MoveMod) 
			{
				TempRolls.Add (i);
			}
		}
		if (TempRolls.Count > 0) 
		{
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].OnSelected ();
			TempRolls.Clear ();
			{
				return;}
		}

		for (int i = 0; i < NUMBER_OF_TREES; i++) {
			if (TreeRolls [i] == BonusAtIndex.SkillUp) {
				TempRolls.Add (i);
				//				Debug.Log ("Add 8s...");
			}
		}
		if (TempRolls.Count > 0) 
		{
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].OnSelected ();
			TempRolls.Clear ();
			{
				return;}
		}


		for (int i = 0; i < NUMBER_OF_TREES; i++) {
			if (TreeRolls [i] == BonusAtIndex.Ability) {
				TempRolls.Add (i);
				//				Debug.Log ("Add 6s...");
			}
		}
		if (TempRolls.Count > 0) 
		{
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].OnSelected ();
			TempRolls.Clear ();
			{
				return;}
		}


		for (int i = 0; i < NUMBER_OF_TREES; i++) {
			if (TreeRolls [i] == BonusAtIndex.Endurance) {
				TempRolls.Add (i);
				//				Debug.Log ("Add 9s...");
			}
		}
		if (TempRolls.Count > 0) {
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].OnSelected ();
			TempRolls.Clear ();
			{
				return;}
		}


		for (int i = 0; i < NUMBER_OF_TREES; i++) 
		{
			if (TreeRolls [i] == BonusAtIndex.Maturity) 
			{
				TempRolls.Add (i);
				//				Debug.Log ("Add 10s...");
			}
		}
		if (TempRolls.Count > 0) 
		{
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].OnSelected ();
			TempRolls.Clear ();
			{
				return;}
		}


		for (int i = 0; i < NUMBER_OF_TREES; i++) 
		{
			if (TreeRolls [i] == BonusAtIndex.CrossTree) 
			{
				TempRolls.Add (i);
				Debug.Log ("Should roll on other tree!");
			}
		}
		if (TempRolls.Count > 0) 
		{
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].OnSelected ();
			TempRolls.Clear ();
			{
				return;
			}
		}

		for (int i = 0; i < NUMBER_OF_TREES; i++) 
		{
			if (TreeRolls [i] == BonusAtIndex.TreeUp) 

			{
				TempRolls.Add (i);
				Debug.Log ("Should roll on higher tree!");

			}
		}
		if (TempRolls.Count > 0) 
		{
			TempRolls.Shuffle ();
			ActiveRolls [TempRolls [0]].OnSelected ();
			TempRolls.Clear ();
			{
				return;
			}
		}	
	}


}

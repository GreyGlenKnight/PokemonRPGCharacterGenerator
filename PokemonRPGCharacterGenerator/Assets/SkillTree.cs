using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;


public class SkillTree : MonoBehaviour 
{
	public SkillTreeDisplay TreeDisplay;
	List<int> Bonuses = new List<int> ();
	public int intrandnumber1;
	public static List <int> IntRandNumber1List = new List <int> ();
	public bool IsTreeFull = false;
	public int MaturityUnlock;


	public void RollOnTree()

	{
		RollTheList (Bonuses);
	}

	public void RollTheList (List <int> LBonus)
	{
		if (LBonus.Count > 0)
		{
			Bonuses.Shuffle ();
		}	
		int intrandnumber1 = LBonus [0] + 1;

		TreeDisplay.RollTheList (LBonus, intrandnumber1);

		if (TreeDisplay.options [intrandnumber1 -1].isOn == false)
		{	
			IntRandNumber1List.Add (intrandnumber1);
		}
	}


	public void SelectMe()
	{
		TreeDisplay.SelectMe (intrandnumber1);
		if (GameManager.instance._SelectionState == SelectionState.Roll) 
		{
			return;
		}
			
		if (Bonuses.Count > 0) 
		{
			intrandnumber1 = Bonuses [0];
			Bonuses.RemoveAt (0);
		}

			IntRandNumber1List.Clear ();
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


		
	public void Awake()
	{
		TreeDisplay = GetComponent<SkillTreeDisplay> ();
		ResetBonuses ();
	}
}
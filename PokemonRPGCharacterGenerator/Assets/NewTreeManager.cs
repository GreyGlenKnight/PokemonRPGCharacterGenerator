using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class NewTreeManager : MonoBehaviour 
{

	public bool IsTreeFull = false;
	public List <SkillTree> TreesToRoll = new List <SkillTree> ();
	public List <int> Bonuses = new List <int> ();


	public void CallTreeRoll()
	{
		if (XPManager.SpendXP () == false) 
		{
			return;
		}
		for (int i = 0; i < TreesToRoll.Count; i++) 
		{
			TreesToRoll[i].RollOnTree ();
		}
	}


}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public enum BonusAtIndex
{
	Skill1, Skill2, Skill3, Skill4, MoveMod, Ability, StatUp, SkillUp, Endurance, Maturity, CrossTree, TreeUp, None
}

public class SkillTreeBonusesAcquired 

{
	public List <BonusAtIndex> BonusesRemaining = new List <BonusAtIndex> ();

	public SkillTreeBonusesAcquired ()
	{
		for (int i = 0; i < 12; i++)
		{
			BonusesRemaining.Add ((BonusAtIndex) i);
//			Debug.Log (i);
		}

	}



}

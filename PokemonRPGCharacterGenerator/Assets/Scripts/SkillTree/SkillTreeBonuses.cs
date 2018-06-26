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

public enum BonusState
{
	Acquired,
	Remaining
}

public class SkillTreeBonuses 

{
	public List <BonusAtIndex> Bonuses = new List <BonusAtIndex> ();

	public SkillTreeBonuses ()
	{
//		for (int i = 0; i < 12; i++)
//		{
//			BonusesRemaining.Add ((BonusAtIndex) i);
//		}
	}
}
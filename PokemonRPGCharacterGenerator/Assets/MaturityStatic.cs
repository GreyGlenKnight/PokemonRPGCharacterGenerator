using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;
using NUnit.Framework;

public static class MaturityStatic 

{
	public static int [] BonusLevels = new int[] 
	{
		2,5,8,11,14,17,20,23,26,29,32,35,38
	};

	public static int [] STABBonuses = new int[] 
	{
		4,10,16,22,28,34,40 
	};

	public static int [] NatureBonuses = new int[] 
	{
		1,9,24,37
	};

	public static int [] AbilitySlotBonuses = new int[] 
	{
		0,3,13
	};

	public static int [] TradeSkillBonuses = new int[] 
	{
		9,16,21,24,30,36
	};




	public static IMaturityBonus GetMaturity (int Maturity)
	{
		if (Maturity >= 41) 
		{
			return null;
		}

		if (BonusLevels.Contains (Maturity) == true) 
		{
			return new BonusLevelMaturityBonus ();
		}

		if (STABBonuses.Contains (Maturity) == true) 
		{
			return new STABBonusMaturityBonus ();
		}

		if (NatureBonuses.Contains (Maturity) == true) 
		{
			return new NatureBonusMaturityBonus ();
		} 

		if (AbilitySlotBonuses.Contains (Maturity) == true) 
		{
			return new AbilitySlotMaturityBonus ();
		} 
		if (TradeSkillBonuses.Contains (Maturity) == true) 
		{
			return new TradeSkillMaturityBonus ();
		}
		//Keep changing this to return null, or add a new class until all ranks are used.
		return new ActiveSkillMaturityBonus ();
		}
}

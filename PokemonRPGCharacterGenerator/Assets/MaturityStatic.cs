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

	public static IMaturityBonus GetMaturity (int Maturity)
	{
		if (Maturity >= 41) 
		{return null;}

		if (BonusLevels.Contains (Maturity) == false)
			return new STABBonusMaturityBonus ();
		else 
		{
			return new BonusLevelMaturityBonus ();
		}
	}
}

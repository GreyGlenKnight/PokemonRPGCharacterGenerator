using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaturityRank 
{
	public int Maturity;
	public string MaturityBonuses;
	public static List <int> NatureLevels = new List <int> ()
	{1,9,24,37};

	public MaturityRank (int _Maturity, string _MaturityBonuses)
	{
		Maturity = _Maturity;
		MaturityBonuses = _MaturityBonuses;
	}

	//Want a function to return a bool to calculate if level is a bonus level or not.

	public static bool IsBonusLevel (int Maturity)
	{
		if ((Maturity -=2) % 3 == 0)	return true;
		return false;
	}

	public static bool IsNatureBonus (int Maturity)
	{
		if (NatureLevels.Contains (Maturity)) return true;
		return false;
	}

	public static bool IsSTABLevel (int Maturity)
	{
		int temp = Maturity - 4;
		if ((temp) % 6  == 0)	return true;
	return false;
	}

public static MaturityBonus GetBonusAtLevel (int Maturity)
{
	if (IsBonusLevel(Maturity) == true)
	{return new BonusLevelMaturityBonus ();}

	if (IsNatureBonus(Maturity) == true)
	{return new NatureBonusMaturityBonus ();}

	if (IsSTABLevel(Maturity) == true)
	{return new STABBonusMaturityBonus ();}

	return null;
}

}

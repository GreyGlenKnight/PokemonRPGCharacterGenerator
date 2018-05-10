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

    public static int[] BreakTreeRank1Bonuses = new int[]
    {
        0,1,4,7,13
    };

    public static int[] BreakTreeRank2Bonuses = new int[]
    {
        10,15,19
    };

    public static int[] BreakTreeRank3Bonuses = new int[]
    {
        18,21,27,33
    };

    public static int[] BreakTreeSlot = new int[]
    {
        0,3,6,18
    };

    public static int[] SpecialTrainingBonuses = new int[]
    {
        6,12,25
    };

    public static int[] EnhancerSlotBonuses = new int[]
    {
        7,15,31,39
    };

    public static List <MaturityBonus> GetMaturityBonuses (int Maturity)
	{
        List <MaturityBonus> ToReturn = new List <MaturityBonus> (); 

		if (Maturity >= 41) 
		{
			return ToReturn;
		}

		if (BonusLevels.Contains (Maturity) == true) 
		{
			ToReturn.Add (new MaturityBonus.BonusLevel (
				(Array.IndexOf (BonusLevels,Maturity)+1)));
		}
		if (STABBonuses.Contains (Maturity) == true) 
		{
            ToReturn.Add (new MaturityBonus.STABBonus (
				(Array.IndexOf (STABBonuses,Maturity)+1)));
		}
		if (NatureBonuses.Contains (Maturity) == true) 
		{
            ToReturn.Add (new MaturityBonus.NatureBonus (
				(Array.IndexOf (NatureBonuses,Maturity)+1)));
		} 
		if (AbilitySlotBonuses.Contains (Maturity) == true) 
		{
            ToReturn.Add (new MaturityBonus.AbilitySlot (
				(Array.IndexOf (AbilitySlotBonuses,Maturity)+1)));
		} 
		if (TradeSkillBonuses.Contains (Maturity) == true) 
		{
            ToReturn.Add (new MaturityBonus.TradeSkill (
				(Array.IndexOf (TradeSkillBonuses,Maturity)+1)));
		}
        if (BreakTreeRank1Bonuses.Contains(Maturity) == true)
        {
            ToReturn.Add(new MaturityBonus.BreakTree(
				(Array.IndexOf (BreakTreeRank1Bonuses,Maturity)+1),1));
        }
        if (BreakTreeRank2Bonuses.Contains(Maturity) == true)
        {
            ToReturn.Add(new MaturityBonus.BreakTree(
				(Array.IndexOf (BreakTreeRank2Bonuses,Maturity)+1),2));
        }
        if (BreakTreeRank3Bonuses.Contains(Maturity) == true)
        {
			ToReturn.Add(new MaturityBonus.BreakTree(
				(Array.IndexOf (BreakTreeRank3Bonuses,Maturity)+1),3));
		}
        if (BreakTreeSlot.Contains(Maturity) == true)
        {
			ToReturn.Add(new MaturityBonus.ActiveSkill (
				(Array.IndexOf (BreakTreeSlot,Maturity)+1)));
        }
        if (SpecialTrainingBonuses.Contains(Maturity) == true)
        {
			ToReturn.Add(new MaturityBonus.SpecialTraining (
				(Array.IndexOf (SpecialTrainingBonuses,Maturity)+1)));
        }
        if (EnhancerSlotBonuses.Contains(Maturity) == true)
        {
			ToReturn.Add(new MaturityBonus.EnhancerSlot (
				(Array.IndexOf (EnhancerSlotBonuses,Maturity)+1)));
        }

        return ToReturn;
    }
}

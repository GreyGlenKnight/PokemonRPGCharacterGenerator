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

	public static int[] BreakTreeRank0Bonuses = new int[]
	{
		0
	};

    public static int[] BreakTreeRank1Bonuses = new int[]
    {
        1,4,7,13
    };

    public static int[] BreakTreeRank2Bonuses = new int[]
    {
        10,15,19
    };

    public static int[] BreakTreeRank3Bonuses = new int[]
    {
        18,21,27,33
    };

    public static int[] ActiveTreeSlot = new int[]
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
				(Array.IndexOf (BonusLevels,Maturity))));
		}
		if (STABBonuses.Contains (Maturity) == true) 
		{
            ToReturn.Add (new MaturityBonus.STABBonus (
				(Array.IndexOf (STABBonuses,Maturity)), ElementTypes.Fire));
		}
		if (NatureBonuses.Contains (Maturity) == true) 
		{
            ToReturn.Add (new MaturityBonus.NatureBonus (
				(Array.IndexOf (NatureBonuses,Maturity)), new AttackStat(1)));
		} 
		if (AbilitySlotBonuses.Contains (Maturity) == true) 
		{
            ToReturn.Add (new MaturityBonus.AbilitySlot (
				(Array.IndexOf (AbilitySlotBonuses,Maturity))));
		} 
		if (TradeSkillBonuses.Contains (Maturity) == true) 
		{
//			Debug.Log ("in MaturityStatic");
			SkillTreeTier _Tier = SkillTreeTier.Tier1;
			if (Maturity > 17) {_Tier = SkillTreeTier.Tier2;}
			if (Maturity > 29) {_Tier = SkillTreeTier.Tier3;}

            ToReturn.Add (new MaturityBonus.TradeSkill (
				(Array.IndexOf (TradeSkillBonuses,Maturity)), _Tier));
		}
		if (BreakTreeRank0Bonuses.Contains(Maturity) == true)
		{
//			Debug.Log (Array.IndexOf (BreakTreeRank0Bonuses,Maturity));
			ToReturn.Add(new MaturityBonus.BreakTree(
				(Array.IndexOf (BreakTreeRank0Bonuses,Maturity)),SkillTreeTier.Tier0));
		}
		if (BreakTreeRank1Bonuses.Contains(Maturity) == true)
        {
            ToReturn.Add(new MaturityBonus.BreakTree(
				(Array.IndexOf (BreakTreeRank1Bonuses,Maturity)),SkillTreeTier.Tier1));
        }
        if (BreakTreeRank2Bonuses.Contains(Maturity) == true)
        {
			Debug.Log ("Tier 2, MaturityStatic");
            ToReturn.Add(new MaturityBonus.BreakTree(
				(Array.IndexOf (BreakTreeRank2Bonuses,Maturity)),SkillTreeTier.Tier2));
        }
        if (BreakTreeRank3Bonuses.Contains(Maturity) == true)
        {
			ToReturn.Add(new MaturityBonus.BreakTree(
				(Array.IndexOf (BreakTreeRank3Bonuses,Maturity)),SkillTreeTier.Tier3));
		}
        if (ActiveTreeSlot.Contains(Maturity) == true)
        {
//			Debug.Log (Maturity);
			int TreeSlot = Array.IndexOf (ActiveTreeSlot,Maturity);
			ToReturn.Add(new MaturityBonus.ActiveSkill (
				(TreeSlot), TreeSlot));
        }
        if (SpecialTrainingBonuses.Contains(Maturity) == true)
        {
			ToReturn.Add(new MaturityBonus.SpecialTraining (
				(Array.IndexOf (SpecialTrainingBonuses,Maturity))));
        }
        if (EnhancerSlotBonuses.Contains(Maturity) == true)
        {
			ToReturn.Add(new MaturityBonus.EnhancerSlot (
				(Array.IndexOf (EnhancerSlotBonuses,Maturity))));
        }

        return ToReturn;
    }
}

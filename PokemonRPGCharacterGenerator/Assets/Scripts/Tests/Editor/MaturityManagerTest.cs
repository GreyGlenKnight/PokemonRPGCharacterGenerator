using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;
using NUnit.Framework;

public class MaturityManagerTest
{
	[Test]
	public void CanGetMaturityBonusForMaturity ()
	{
		IMaturityBonus Bonus = MaturityStatic.GetMaturity (1);
		UnityEngine.Debug.Assert (
			Bonus != null);
	}

	[Test]
	public void CanReturnDifferentBonusTypes ()
	{
		IMaturityBonus Bonus = MaturityStatic.GetMaturity (1);
		IMaturityBonus Bonus2 = MaturityStatic.GetMaturity (2);
		UnityEngine.Debug.Assert (
			Bonus.GetType().Equals (Bonus2.GetType()) == false);
	}

	[Test]
	public void ReturnBonusLevelMaturityBonusAtLevel2 ()
	{
		IMaturityBonus Bonus = MaturityStatic.GetMaturity (2);
		UnityEngine.Debug.Assert (
			Bonus.GetType().Equals (typeof (BonusLevelMaturityBonus)) == true);
	}

	[Test]
	public void ReturnBonusLevelMaturityBonusAtLevel5 ()
	{
		IMaturityBonus Bonus = MaturityStatic.GetMaturity (5);
		UnityEngine.Debug.Assert (
			Bonus.GetType().Equals (typeof (BonusLevelMaturityBonus)) == true);
	}

	[Test]
	public void ReturnTypeAtLevel4IsNotBonusLevel ()
	{
		IMaturityBonus Bonus = MaturityStatic.GetMaturity (4);
		UnityEngine.Debug.Assert (
			Bonus.GetType().Equals (typeof (BonusLevelMaturityBonus)) == false);
	}

	[Test]
	public void NoBonusesGainedAfter41 ()
	{
		IMaturityBonus Bonus = MaturityStatic.GetMaturity (42);
		UnityEngine.Debug.Assert (
			Bonus == null);
	}

	[Test]
	public void ReturnSTABBonusMaturityBonusAtLevel4 ()
	{
		IMaturityBonus Bonus = MaturityStatic.GetMaturity (4);
		UnityEngine.Debug.Assert (
			Bonus.GetType().Equals (typeof (STABBonusMaturityBonus)) == true);
	}

	[Test]
	public void DontReturnSTABBonusMaturityBonusAtLevel6 ()
	{
		IMaturityBonus Bonus = MaturityStatic.GetMaturity (6);
		UnityEngine.Debug.Assert (
			Bonus.GetType().Equals (typeof (STABBonusMaturityBonus)) == false);
	}

	[Test]
	public void ReturnBonusForEveryMaturityRank ()
	{
		for (int i = 0; i < 41; i++)
		{
		IMaturityBonus Bonus = MaturityStatic.GetMaturity (i);
		UnityEngine.Debug.Assert (
			Bonus != null);
		}
	}

	[Test]
	public void DontReturnNatureBonusMaturityBonusAtLevel0 ()
	{
		{
			IMaturityBonus Bonus = MaturityStatic.GetMaturity (0);
			UnityEngine.Debug.Assert (
				Bonus.GetType().Equals (typeof (NatureBonusMaturityBonus)) == false);
		}
	}

	[Test]
	public void ReturnAbilitySlotBonusAtMaturity0 ()
	{
		{
			IMaturityBonus Bonus = MaturityStatic.GetMaturity (0);
			UnityEngine.Debug.Assert (
				Bonus.GetType().Equals (typeof (AbilitySlotMaturityBonus)) == true);
		}
	}

	[Test]
	public void DontReturnAbilitySlotBonusAtMaturity1 ()
	{
		{
			IMaturityBonus Bonus = MaturityStatic.GetMaturity (1);
			UnityEngine.Debug.Assert (
				Bonus.GetType().Equals (typeof (AbilitySlotMaturityBonus)) == false);
		}
	}

//	[Test]
//	public void ReturnTradeSkillMaturityBonusAtMaturity9 ()
//	{
//		{
//			IMaturityBonus Bonus = MaturityStatic.GetMaturity (9);
//
//			UnityEngine.Debug.Assert (
//				Bonus.GetType().Equals (typeof (TradeSkillMaturityBonus)) == true);
//		}
//	}

	[Test]
	public void DontReturnTradeSkillMaturityBonusAtMaturity1 ()
	{
		{
			IMaturityBonus Bonus = MaturityStatic.GetMaturity (1);
			UnityEngine.Debug.Assert (
				Bonus.GetType().Equals (typeof (TradeSkillMaturityBonus)) == false);
		}
	}

//
//DontGetSameBonusTwice
//ReturnMultipleBonuses
//ReturnStringForMaturity
}

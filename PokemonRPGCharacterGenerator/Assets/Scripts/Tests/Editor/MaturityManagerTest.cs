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



}

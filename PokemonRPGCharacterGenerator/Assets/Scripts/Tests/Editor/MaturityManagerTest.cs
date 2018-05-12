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
        List<MaturityBonus> Bonus = MaturityStatic.GetMaturityBonuses (1);
		UnityEngine.Debug.Assert (
			Bonus != null);
	}

	[Test]
	public void CanReturnDifferentBonusTypes ()
	{
        List<MaturityBonus> Bonus = MaturityStatic.GetMaturityBonuses (1);
        List<MaturityBonus> Bonus2 = MaturityStatic.GetMaturityBonuses (2);
		UnityEngine.Debug.Assert (
			Bonus[0].GetType().Equals (Bonus2[0].GetType()) == false);
	}

	[Test]
	public void ReturnBonusLevelMaturityBonusAtLevel2 ()
	{
        List<MaturityBonus> Bonus = MaturityStatic.GetMaturityBonuses (2);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.BonusLevel));
        };

        Debug.Assert(Bonus.Find(predicate) != null);

   //     UnityEngine.Debug.Assert (
			//Bonus.GetType().Equals (typeof (MaturityBonus.BonusLevel)) == true);
	}

	[Test]
	public void ReturnBonusLevelMaturityBonusAtLevel5 ()
	{
        List<MaturityBonus> Bonus = MaturityStatic.GetMaturityBonuses (5);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.BonusLevel));
        };

        Debug.Assert(Bonus.Find(predicate) != null);

   //     UnityEngine.Debug.Assert (
			//Bonus.GetType().Equals (typeof (MaturityBonus.BonusLevel)) == true);
	}

	[Test]
	public void ReturnTypeAtLevel4IsNotBonusLevel ()
	{
        List<MaturityBonus> Bonus = MaturityStatic.GetMaturityBonuses (4);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.BonusLevel));
        };

        Debug.Assert(Bonus.Find(predicate) == null);


   //     UnityEngine.Debug.Assert (
			//Bonus.GetType().Equals (typeof (MaturityBonus.BonusLevel)) == false);
	}

	[Test]
	public void NoBonusesGainedAfter41 ()
	{
        List<MaturityBonus> Bonus = MaturityStatic.GetMaturityBonuses (42);

		UnityEngine.Debug.Assert (
			Bonus.Count == 0);
	}

	[Test]
	public void ReturnSTABBonusMaturityBonusAtLevel4 ()
	{
        List<MaturityBonus> Bonus = MaturityStatic.GetMaturityBonuses (4);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.STABBonus));
        };

        Debug.Assert(Bonus.Find(predicate) != null);

   //     UnityEngine.Debug.Assert (
			//Bonus.GetType().Equals (typeof (MaturityBonus.STABBonus)) == true);
	}

	[Test]
	public void DontReturnSTABBonusMaturityBonusAtLevel6 ()
	{
        List<MaturityBonus> Bonus = MaturityStatic.GetMaturityBonuses (6);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.STABBonus));
        };

        Debug.Assert(Bonus.Find(predicate) == null);

   //     UnityEngine.Debug.Assert (
			//Bonus.GetType().Equals (typeof (MaturityBonus.STABBonus)) == false);
	}

	[Test]
	public void ReturnBonusForEveryMaturityRank ()
	{
        int timesReturnedMaturityBonus = 0;

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return true;
        };

        for (int i = 0; i < 41; i++)
		{
            List<MaturityBonus> Bonus = MaturityStatic.GetMaturityBonuses (i);

            if(Bonus.Find(predicate) != null)
            {
                timesReturnedMaturityBonus++;
            }
		}

        Debug.Assert(timesReturnedMaturityBonus == 41);

	}

	[Test]
	public void DontReturnNatureBonusMaturityBonusAtLevel0 ()
	{
        List<MaturityBonus> Bonus = MaturityStatic.GetMaturityBonuses (0);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.NatureBonus));
        };

        Debug.Assert(Bonus.Find(predicate) == null);
	}

	[Test]
	public void ReturnAbilitySlotBonusAtMaturity0 ()
	{
        List<MaturityBonus> Bonus = MaturityStatic.GetMaturityBonuses (0);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.AbilitySlot));
        };

        Debug.Assert(Bonus.Find(predicate) != null);

	}

	[Test]
	public void DontReturnAbilitySlotBonusAtMaturity1 ()
	{
        List<MaturityBonus> Bonus = MaturityStatic.GetMaturityBonuses (1);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.AbilitySlot));
        };

        Debug.Assert(Bonus.Find(predicate) == null);

	}



	[Test]
	public void DontReturnTradeSkillMaturityBonusAtMaturity1 ()
	{
        List<MaturityBonus> Bonus = MaturityStatic.GetMaturityBonuses (1);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.TradeSkill));
        };

        Debug.Assert(Bonus.Find(predicate) == null);
    }

    [Test]
    public void Returns_Break_Tree_On_Level_0()
    {
        List<MaturityBonus> maturityBonus = MaturityStatic.GetMaturityBonuses(0);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.BreakTree));
        };
        Debug.Assert(maturityBonus.Find(predicate) != null);
    }

    [Test]
    public void Dont_Return_Break_Tree_At_Level_2()
    {
        List<MaturityBonus> maturityBonus = MaturityStatic.GetMaturityBonuses(2);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.BreakTree));
        };
        Debug.Assert(maturityBonus.Find(predicate) == null);
    }

    [Test]
    public void Return_Special_Training_At_Level_6()
    {
        List<MaturityBonus> maturityBonus = MaturityStatic.GetMaturityBonuses(6);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.SpecialTraining));
        };
        Debug.Assert(maturityBonus.Find(predicate) != null);
    }

    [Test]
    public void Return_Active_Tree_At_Level_0()
    {
        List<MaturityBonus> maturityBonus = MaturityStatic.GetMaturityBonuses(0);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.ActiveSkill));
        };
        Debug.Assert(maturityBonus.Find(predicate) != null);
    }

    [Test]
    public void Does_Not_Return_Special_Training_At_33()
    {
        List<MaturityBonus> maturityBonus = MaturityStatic.GetMaturityBonuses(33);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.SpecialTraining));
        };
        Debug.Assert(maturityBonus.Find(predicate) == null);
    }

    [Test]
    public void Returns_Break_Skill_At_Level_15()
    {
        List<MaturityBonus> maturityBonus = MaturityStatic.GetMaturityBonuses(15);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.BreakTree));
        };
        Debug.Assert(maturityBonus.Find(predicate) != null);
    }
    [Test]
    public void Does_Not_Returns_Enhancer_Skill_At_Level_16 ()
    {
        List<MaturityBonus> maturityBonus = MaturityStatic.GetMaturityBonuses(16);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.EnhancerSlot));
        };
        Debug.Assert(maturityBonus.Find(predicate) == null);
    }

    [Test]
    public void Break_Level_Is_2_For_BreakTree_At_Level_15()
    {
        List<MaturityBonus> maturityBonus = MaturityStatic.GetMaturityBonuses(15);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            MaturityBonus.BreakTree breakTree = x as MaturityBonus.BreakTree;

            return breakTree.BreakLevel == 2;
        };
        Debug.Assert(maturityBonus.Find(predicate) != null);
    }

    [Test]
    public void Break_Level_Is_1_For_BreakTree_At_Level_4()
    {
        List<MaturityBonus> maturityBonus = MaturityStatic.GetMaturityBonuses(4);

        Predicate<MaturityBonus> predicate = (x) =>
        {
            MaturityBonus.BreakTree breakTree = x as MaturityBonus.BreakTree;
            if (breakTree == null)
                return false;

            return breakTree.BreakLevel == 1;
        };
        Debug.Assert(maturityBonus.Find(predicate) != null);
    }

    [Test]
    public void Returns_A_Total_Of_55_Bonuses()
    {
        List<MaturityBonus> maturityBonus = new List<MaturityBonus>();

        for (int i = 0; i < 41; i++)
        {
            maturityBonus.AddRange(MaturityStatic.GetMaturityBonuses(i));
        }
//        Predicate<MaturityBonus> predicate = (x) =>
//        {
//            MaturityBonus.BreakTree breakTree = x as MaturityBonus.BreakTree;
//
//            return breakTree.BreakLevel == 1;
//        };
        Debug.Log(maturityBonus.Count);
        Debug.Assert(maturityBonus.Count == 56);
    }

    [Test]
    public void Gain_A_Total_Of_4_Enhancers() 
    {
        List<MaturityBonus> maturityBonus = new List<MaturityBonus>();

        for (int i = 0; i < 41; i++)
        {
            maturityBonus.AddRange (MaturityStatic.GetMaturityBonuses(i));
        }

        Predicate<MaturityBonus> predicate = (x) =>
        {
            return x.GetType().Equals(typeof(MaturityBonus.EnhancerSlot));
        };

        List<MaturityBonus> allEnhancerSlots = maturityBonus.FindAll(predicate);


        Debug.Log (allEnhancerSlots.Count);
        Debug.Assert(allEnhancerSlots.Count == 4);
    }

    [Test]
    public void Maturity_Bonus_Contains_Description()
    {
        List<MaturityBonus> maturityBonus = MaturityStatic.GetMaturityBonuses(4);
        Debug.Assert(maturityBonus[0].Description != "");
    }

    [Test]
    public void Maturity_Bonus_Have_Different_Descriptions()
    {
        List<MaturityBonus> maturityBonus = MaturityStatic.GetMaturityBonuses(0);
        Debug.Log(maturityBonus[0].Description + maturityBonus[1].Description);
        Debug.Assert(maturityBonus[0].Description != maturityBonus[1].Description);
    }

    [Test]
    public void Maturity_Bonuses_Track_Their_Index()
    {
        //TODO add to Maturity Bonus tests
        List<MaturityBonus> maturityBonus = new List<MaturityBonus> ();
        maturityBonus.AddRange(MaturityStatic.GetMaturityBonuses(2));
        maturityBonus.AddRange(MaturityStatic.GetMaturityBonuses(5));
		Debug.Log (maturityBonus [0].Description);
		Debug.Log (maturityBonus [1].Description);
        Debug.Assert(maturityBonus[0].Description != maturityBonus[1].Description);
    }

//	[Test]
//	public void MaturityBonusAreFormatted ()
//	{
//		List<MaturityBonus> maturityBonus = new List<MaturityBonus> ();
//		for (int i = 0; i < 56; i++) 
//		{
//			//The Debug Log returns the position on the list, not the 
//	//maturity, so there will only be about 2/3 of the bonuses at 40.
//			maturityBonus.AddRange (MaturityStatic.GetMaturityBonuses (i));
//			Debug.Log (maturityBonus [i].Description);
//			Debug.Log (i);
//		}
//	}
//
    //DontGetSameBonusTwice
    //ReturnStringForMaturity
}



﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonClass 
{
	public int Maturity;
	public int Level;
//	public SkillTrees _SkillTrees;

	public List<SkillTreeData> _SkillTreeData = new List<SkillTreeData>();
	public List <SkillTreeBonusesAcquired> _BonusesRemaining = new List <SkillTreeBonusesAcquired>();

    public PokemonClass ()
    {
		
        Level = 0;
        _SkillTreeData.Add(new SkillTreeData("Imp", SkillTreeTier.Tier0));
        _SkillTreeData.Add(new SkillTreeData("Drake", SkillTreeTier.Tier1));
        _SkillTreeData.Add(new SkillTreeData("Fire Body 1", SkillTreeTier.Tier1));
        _SkillTreeData.Add(new SkillTreeData("Claw 1", SkillTreeTier.Tier1));
        _SkillTreeData.Add(new SkillTreeData("Claw 2", SkillTreeTier.Tier2));
        _SkillTreeData.Add(new SkillTreeData("Beast", SkillTreeTier.Tier1));
        _SkillTreeData.Add(new SkillTreeData("Fire Body 2", SkillTreeTier.Tier2));
        _SkillTreeData.Add(new SkillTreeData("Pyromancer 1", SkillTreeTier.Tier1));
        _SkillTreeData.Add(new SkillTreeData("Pureblood 2", SkillTreeTier.Tier2));
        _SkillTreeData.Add(new SkillTreeData("Pureblood 3", SkillTreeTier.Tier3));
        _SkillTreeData.Add(new SkillTreeData("Fire Body 3", SkillTreeTier.Tier3));
        _SkillTreeData.Add(new SkillTreeData("Acrobatics 1", SkillTreeTier.Tier1));

		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());


    }


    public void LevelUp ()
	{
//		Debug.Log ("Gained LevelUp");
//		GainMaturity ()
//		{}
		Level++;
	}

	public void PokemonTreeSwap ()
	{
		SkillTreeData TempData = _SkillTreeData [0];
		_SkillTreeData [4] = _SkillTreeData [0];
		_SkillTreeData [0] = TempData;

	}


	public void GainNatureBonus ()
	{
		Debug.Log ("Gained Nature :"+Maturity);
	}

	public void GainSTABBonus ()
	{
		Debug.Log ("Gained STAB :"+Maturity);
	}

	public void ApplyMaturityBonus (IMaturityBonus MBonus, int maturity)
	{
		Maturity = maturity;
		if (MBonus == null) 
		{
			return;
		}
			MBonus.ApplyBonus (this);	
	}


}
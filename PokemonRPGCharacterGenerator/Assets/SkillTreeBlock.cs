using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class SkillTreeBlock

{
public List <SkillTree> _SkillTrees = new List <SkillTree>();
public Pokemon _Pokemon;

public List <SkillTree> GetSkillTreesForTier (SkillTreeTier _Tier)
{
	List <SkillTree> Temp = new List <SkillTree> ();

	for (int i = 0; i < _SkillTrees.Count; i++) 
	{
		if (_SkillTrees [i].Tier == _Tier) 
		{
			Temp.Add (_SkillTrees [i]);
		}
	}
	return Temp;
}

private SkillTree AutoChooseTree (SkillTreeTier _Tier)
{
	List <SkillTree> Temp = new List <SkillTree> ();
	SkillTree ToReturn;

	switch (_Tier)
	{	
	case SkillTreeTier.Tier0 | SkillTreeTier.Tier1:
		Temp.Concat (GetSkillTreesForTier (SkillTreeTier.Tier0));
		Temp.Concat (GetSkillTreesForTier (SkillTreeTier.Tier1));
		Temp.Shuffle ();
		ToReturn = Temp [0];
		return ToReturn;
	case SkillTreeTier.Tier2:
		Temp.Concat (GetSkillTreesForTier (SkillTreeTier.Tier2));
		Temp.Shuffle ();
		ToReturn = Temp [0];
		return ToReturn;
	case SkillTreeTier.Tier3:
		Temp.Concat (GetSkillTreesForTier (SkillTreeTier.Tier3));
		Temp.Shuffle ();
		ToReturn = Temp [0];
		return ToReturn;
	default:
		Debug.Log ("This pokemon has gone Super Saiyan" + _Tier);
		return null;
	}
}

	public SkillTreeBlock (Pokemon PokemonToUse)
	{
		_Pokemon = PokemonToUse;
		_SkillTrees.Add (new SkillTree("Imp", SkillTreeTier.Tier0));
		_SkillTrees.Add (new SkillTree("Drake", SkillTreeTier.Tier1));
		_SkillTrees.Add (new SkillTree("Fire Body 1", SkillTreeTier.Tier1));
		_SkillTrees.Add (new SkillTree("Claw 1", SkillTreeTier.Tier1));
		_SkillTrees.Add (new SkillTree("Beast", SkillTreeTier.Tier1));
		_SkillTrees.Add (new SkillTree("Pyromancer 1", SkillTreeTier.Tier1));

		_SkillTrees.Add (new SkillTree("Claw 2", SkillTreeTier.Tier2));
		_SkillTrees.Add (new SkillTree("Fire Body 2", SkillTreeTier.Tier2));
		_SkillTrees.Add (new SkillTree("Pureblood 2", SkillTreeTier.Tier2));

		_SkillTrees.Add (new SkillTree("Pureblood 3", SkillTreeTier.Tier3));
		_SkillTrees.Add (new SkillTree("Fire Body 3", SkillTreeTier.Tier3));
		_SkillTrees.Add (new SkillTree("Acrobatics 1", SkillTreeTier.Tier1));
	}

public void SwapTrees (SkillTreeTier Tier)
{
	_SkillTrees [0].ChangeTreeState (SkillTreeState.Inactive);
	_SkillTrees [3].ChangeTreeState (SkillTreeState.Active);
	SkillTree TempData2 = _SkillTrees [3];
	SkillTree TempData = _SkillTrees [0];
	_SkillTrees [0] = TempData2;
	_SkillTrees [3] = TempData;
}

	public void GainBreakTree (SkillTreeTier _Tier)
	{
		UnlockTrees (_Tier);
		Debug.Log ("Gained Break Tree :" + _Pokemon.Maturity);
	}

	public void GainActiveTreeBonus (int TreeSlot)
	{
		ActivateTrees (TreeSlot);
		Debug.Log ("Gained Active Tree :"+ _Pokemon.Maturity);
	}


	public void UnlockTrees (SkillTreeTier _Tier)
	{
		//		SkillTree TreeToAdd = AutoChooseTree (_Tier);
		//		_SkillTrees.Add (TreeToAdd);

		for (int i = 0; i < _SkillTrees.Count; i++) 
		{
			if (_SkillTrees [i].CurrentState == SkillTreeState.Locked) 
			{
				_SkillTrees [i].ChangeTreeState (SkillTreeState.Inactive);
				return;
			}
		}
	}

	public void ActivateTrees (int TreeSlot)
	{
		_SkillTrees [TreeSlot].ChangeTreeState (SkillTreeState.Active);
	}

	public List <ILevelUpOption> RollOnTrees ()
	{
		if (_Pokemon.XP < 2) 
		{
			Debug.Log ("XP Spend Fail");
			return null;
		}
		Debug.Log (GameManager.instance._SelectionState);
		if (GameManager.instance._SelectionState == SelectionState.Select) 
		{
			Debug.Log ("Selection State is Select");
			return null;
		}
			
		List <SkillTree> TreesToRoll = new List <SkillTree> ();

		for (int i = 0; i < _SkillTrees.Count; i++) 
		{
			SkillTree Temp = _SkillTrees [i].GetTreeIfActive ();
			if (Temp != null) 
			{
				TreesToRoll.Add (Temp);
			}
		}

		List <ILevelUpOption> TempOptions = new List <ILevelUpOption> ();

		for (int i = 0; i < TreesToRoll.Count; i++) 
		{
			if (TreesToRoll [i].GetRemainingBonuses ().Count > 0) 
			{
				TempOptions.Add (TreesToRoll [i].GetRandomAvailableBonus ());

//				if (TempOptions [i].TypeOfBonus == BonusAtIndex.CrossTree) 
//				{
//				}
//
//				if (TempOptions [i].TypeOfBonus == BonusAtIndex.TreeUp) 
//				{
//				}
			}
		}

		GameManager.instance._SelectionState = SelectionState.Select;

		return TempOptions;
	}
}
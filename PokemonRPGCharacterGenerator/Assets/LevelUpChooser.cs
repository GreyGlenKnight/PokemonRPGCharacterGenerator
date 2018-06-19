using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelUpChooser 
{
//	public List <MyStat> _StatOptions;
//	List <LevelUpBonus> BonusesToDisplay = new List <LevelUpBonus>();
//	List <SkillTreeData> TreesToDisplay = new List <SkillTreeData> ();
//	InterruptDialog _InterruptDialog;
//	Pokemon FuturePokemon;

	//May not need new list?
	//Need references to the UI resources

	//NewTreeManager is the larger class, passes in the type of bonus, 
	//trees, and copy of the pokemon.
	//
	//from the copy of the pokemon, we can calculate what the updated stats would be
	//we can use the bonus type and tree to get the description and data
	//then we pass those values in to the display stuff and let interrupt dialog display them
	//how we want.

//	public static void RollForStats (MyStat _Stat)
//	{
//		_StatOptions = MyStat.RollStatChoices (_Stat);
//
//	}
//
//	public void ChooseStat1 ()
//	{
//		OnSelected (_StatOptions [0]);
//	}
//
//	public void ChooseStat2 ()
//	{
//		OnSelected (_StatOptions [1]);
//	}
//	public LevelUpChooser (List <SkillTreeData> _Trees, 
//		List <BonusAtIndex> _Bonuses,
//		Pokemon _Pokemon)
//	{
//		BonusesToDisplay = _Bonuses;
//		TreesToDisplay = _Trees;
//		FuturePokemon = new Pokemon (_Pokemon);
//	}

//	public void PokemonLevelsUp ()
//	{
//		for (int i = 0; i < TreesToDisplay.Count; i++) 
//		{
//			Pokemon TempPokemon = new Pokemon (FuturePokemon);
//			TempPokemon.ApplyLevelBonus(BonusAtIndex [i], Tree [i]);
//			CreateDisplay (TempPokemon, BonusAtIndex [i], Tree [i]);
//		}
//	}

//	public void CreateDisplay ()

//	 	For Each TreesToDisplay:
//	{
//		NewTreeManager.GetBonusAtIndex
//		NewTreeManager.GetTree
//		NewTreeManager.CopyCurrentPokemon();
//		FuturePokemon.ApplyLevelBonus(BonusAtIndex [i], Tree [i]);
//		InterruptDialog CreateDisplay [i] (FuturePokemon, BonusAtIndex [i], Tree [i])
//	}



//	public void CalculateFuturePokemon (Pokemon _Pokemon)
//	{
//		FuturePokemon = new Pokemon (_Pokemon);
//	}

//	public void PopulateLists (SkillTreeData _Tree, 
//		BonusAtIndex _Bonus)
//	{
//		TreesToDisplay.Add (_Tree);
//		BonusesToDisplay.Add (_Bonus);
//	}


//	public void DisplayBonuses (List <LevelUpBonus> _LevelUpBonuses)
//	{
//		BonusesToDisplay = _LevelUpBonuses;
//
//	}
}

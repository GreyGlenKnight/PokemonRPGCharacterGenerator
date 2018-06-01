using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;


public static class ListExtensions

{	
	private static System.Random rng = new System.Random();  
	public static void Shuffle<T>(this IList<T> list)  

	{  
		int n = list.Count;  
		while (n > 1) 
		{  
			n--;  
			int k = rng.Next(n + 1);  
			T value = list[k]; 
			list[k] = list[n];  
			list[n] = value;  
		}  
	}

//	public static void ApplyMethodToList ()
//	{
//		
//	}
}

public enum SelectionState
{
	Roll,
	Select
}

public enum TreeRowState
{
	Baby,
	Mid,
	Adult
}

public class GameManager : MonoBehaviour 

{
	public static GameManager instance = null;
	public NewTreeManager _NewTreeManager;
	public SelectionState _SelectionState = SelectionState.Roll;
	public Pokemon CurrentPokemon;
	public TreeRowState TreeRowState;
	public BadgeLevelGenerator _BadgeLevelGenerator;
	public PokemonSheetDisplay _PokemonSheetDisplay;



	void Awake()

	{
		
		if (instance == null)
		{instance = this;}
			
		else  if (instance != this)
		{Destroy (gameObject);}
		DontDestroyOnLoad(gameObject);

		Pokemon.Breed CharmanderBreed = new Pokemon.Breed (ElementTypes.Fire, ElementTypes.Nothing);
		CharmanderBreed.BreedName = "Charmander";
		CharmanderBreed.BaseEndurance.RawValue = 4;
		CharmanderBreed.BaseAttack.RawValue = 5;
		CharmanderBreed.BaseDefense.RawValue = 4;
		CharmanderBreed.BaseSpecialAttack.RawValue = 5;
		CharmanderBreed.BaseSpecialDefense.RawValue = 4;
		CharmanderBreed.BaseSpeed.RawValue = 6;


		CurrentPokemon = new Pokemon (CharmanderBreed);
		CurrentPokemon.Maturity = 0;
		CurrentPokemon.Level = 0;
		CurrentPokemon.Rate = 5;
		CurrentPokemon.NumberOfEnduranceBonuses = 3;
		CurrentPokemon.NumberOfAttackBonuses = 1;
		CurrentPokemon.NumberOfDefenseBonuses = 1;
		CurrentPokemon.NumberOfSpecialAttackBonuses = 0;
		CurrentPokemon.NumberOfSpecialDefenseBonuses = 2;
		CurrentPokemon.NumberOfSpeedBonuses = 0;
		CurrentPokemon.CurrentDamage = 0;
		CurrentPokemon.CurrentStrainLost = 0;
//		ChangeVisibleTrees ();
//		CurrentPokemon.ApplyMaturityBonus (MaturityStatic.GetMaturityBonuses (CurrentPokemon.Maturity), CurrentPokemon.Maturity);
//		CurrentPokemon.UnlockTrees ();
		_NewTreeManager.ChangeDisplayPokemon (CurrentPokemon);
		Refresh ();
		_PokemonSheetDisplay.ShowNewPokemon (CurrentPokemon, CharmanderBreed);

		Technique Fire_Blast = new Technique ();
		Fire_Blast.BaseAccuracy = -1;
		Fire_Blast.BaseDamage = 11;
		Fire_Blast.BaseStrain = 4;
		Fire_Blast.Description = "A fiery runic symbol strikes the foe, inflicting heavy damage and burn.";
		Fire_Blast.DisplayRange = "Ranged";
		Fire_Blast.Name = "Fire Blast";
		Fire_Blast.StatsUsed.Add (new SpecialAttackStat(0));
		Fire_Blast.Types.Add (ElementTypes.Fire);

		Technique Dragon_Claw = new Technique ();
		Dragon_Claw.BaseAccuracy = 1;
		Dragon_Claw.BaseDamage = 8;
		Dragon_Claw.BaseStrain = 3;
		Dragon_Claw.Description = "The foe is ravaged by a mighty swipe of the pokemon’s claws.";
		Dragon_Claw.DisplayRange = "Melee";
		Dragon_Claw.Name = "Dragon Claw";
		Dragon_Claw.StatsUsed.Add (new AttackStat(0));
		Dragon_Claw.Types.Add (ElementTypes.Dragon);

		Technique Metal_Claw = new Technique ();
		Metal_Claw.BaseAccuracy = 0;
		Metal_Claw.BaseDamage = 5;
		Metal_Claw.BaseStrain = 2;
		Metal_Claw.Description = "The pokemon gouges the opponent with a set of merciless claws. May raise Attack.";
		Metal_Claw.DisplayRange = "Melee";
		Metal_Claw.Name = "Metal Claw";
		Metal_Claw.StatsUsed.Add (new AttackStat(0));
		Metal_Claw.Types.Add (ElementTypes.Steel);

		Technique Sand_Attack = new Technique ();
		Sand_Attack.BaseAccuracy = 1;
		Sand_Attack.BaseStrain = 3;
		Sand_Attack.Description = "Norris always teaches his pokemon to be prepared for snakes.";
		Sand_Attack.DisplayRange = "Ranged";
		Sand_Attack.Name = "Sand Attack";
		Sand_Attack.StatsUsed.Add (new DefenseStat(0));
		Sand_Attack.StatsUsed.Add (new SpeedStat(0));
		Sand_Attack.Types.Add (ElementTypes.Ground);

		Technique Hone_Claws = new Technique ();
		Hone_Claws.BaseStrain = 3;
		Hone_Claws.Description = "Obviously works well with all the claw moves.";
		Hone_Claws.DisplayRange = "Self";
		Hone_Claws.Name = "Hone Claws";
		Hone_Claws.Types.Add (ElementTypes.Dark);

		CurrentPokemon._TechniquesKnown.Add (Fire_Blast);
		CurrentPokemon._TechniquesKnown.Add (Dragon_Claw);
		CurrentPokemon._TechniquesKnown.Add (Metal_Claw);
		CurrentPokemon._TechniquesKnown.Add (Sand_Attack);
		CurrentPokemon._TechniquesKnown.Add (Hone_Claws);

		CurrentPokemon._TechniquesActive.Add (Fire_Blast);
		CurrentPokemon._TechniquesActive.Add (Dragon_Claw);
		CurrentPokemon._TechniquesActive.Add (Metal_Claw);
		CurrentPokemon._TechniquesActive.Add (Sand_Attack);
		CurrentPokemon._TechniquesActive.Add (Hone_Claws);

		for (int i = 0; i < CurrentPokemon._TechniquesKnown.Count; i++) 
		{
			_PokemonSheetDisplay.TechsList [i].ChangeTechniqueDisplay (CurrentPokemon._TechniquesActive [i]);
		}
	}

	public void Refresh ()
	{
//		Debug.Log(_TreeRowState);
		_NewTreeManager.Refresh ();
//		switch (_TreeRowState)
//		{
//		case TreeRowState.Baby:
//			TreeSwap (0,0);
//			TreeSwap (1,1);
//			TreeSwap (2,2);
//			TreeSwap (3,3);
//			break;
//		case TreeRowState.Mid:
//			TreeSwap (0,4);
//			TreeSwap (1,5);
//			TreeSwap (2,6);
//			TreeSwap (3,7);
//			break;
//		case TreeRowState.Adult:
//			TreeSwap (0,8);
//			TreeSwap (1,9);
//			TreeSwap (2,10);
//			TreeSwap (3,11);
//			break;
//		default:
//			Debug.Log("There is a new View add logic here. view name is " + _TreeRowState);
//			break;
//		}
	}

	public void ChangeVisibleTrees ()
	{
//		Refresh ();
		_NewTreeManager.ChangeVisibleTrees ();
//		switch (_TreeRowState)
//		{
//		case TreeRowState.Baby:
//
//			_TreeRowState = TreeRowState.Mid;
//			Refresh ();
//
//			break;
//
//		case TreeRowState.Mid:
//
//			_TreeRowState = TreeRowState.Adult;
//			Refresh ();
//
//			break;
//
//		case TreeRowState.Adult:
//
//			_TreeRowState = TreeRowState.Baby;
//			Refresh ();
//
//			break;
//
//		default:
//			Debug.Log("There is a new View add logic here. view name is " + _TreeRowState);
//			break;
//		}

	}

	public void TreeSwap (int TreeToChange, int TreeDataIndex)
	{
//		Debug.Log (CurrentPokemon._SkillTreeData [TreeDataIndex].Name);
//			_NewTreeManager.TreesToRoll [TreeToChange].ChangeDisplayData (	
//			TreeDataIndex,
//			CurrentPokemon._SkillTreeData [TreeDataIndex]);
//				Debug.Log (TreeToChange+" "+TreeDataIndex);
		_NewTreeManager.TreeSwap (TreeToChange, TreeDataIndex);
	}

}

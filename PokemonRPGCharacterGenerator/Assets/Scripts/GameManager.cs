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
	public TreeRowState _TreeRowState;
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
		_TreeRowState = TreeRowState.Baby;
//		ChangeVisibleTrees ();
//		CurrentPokemon.ApplyMaturityBonus (MaturityStatic.GetMaturityBonuses (CurrentPokemon.Maturity), CurrentPokemon.Maturity);
//		CurrentPokemon.UnlockTrees ();
		Refresh ();
		_PokemonSheetDisplay.ShowNewPokemon (CurrentPokemon, CharmanderBreed);
//		_PokemonSheetDisplay.SetTypes (CurrentPokemon, CharmanderBreed);
//		_PokemonSheetDisplay.SetNames (CurrentPokemon, CharmanderBreed);
//		_PokemonSheetDisplay.SetXP (CurrentPokemon);
//		_PokemonSheetDisplay.SetItem (CurrentPokemon);
//		_PokemonSheetDisplay.SetRate (CurrentPokemon);
//		_PokemonSheetDisplay.SetVitals (CurrentPokemon);
//		_PokemonSheetDisplay.SetStatBlock (CurrentPokemon, CharmanderBreed);
//		_PokemonSheetDisplay.SetPortrait  (CurrentPokemon);
//		_PokemonSheetDisplay.SetAbilities (CurrentPokemon);
		//SetMoves()
		//SetSkillRanks ()
	}

	public void Refresh ()
	{
//		Debug.Log(_TreeRowState);

		switch (_TreeRowState)
		{
		case TreeRowState.Baby:
			TreeSwap (0,0);
			TreeSwap (1,1);
			TreeSwap (2,2);
			TreeSwap (3,3);
			break;
		case TreeRowState.Mid:
			TreeSwap (0,4);
			TreeSwap (1,5);
			TreeSwap (2,6);
			TreeSwap (3,7);
			break;
		case TreeRowState.Adult:
			TreeSwap (0,8);
			TreeSwap (1,9);
			TreeSwap (2,10);
			TreeSwap (3,11);
			break;
		default:
			Debug.Log("There is a new View add logic here. view name is " + _TreeRowState);
			break;
		}
	}

	public void ChangeVisibleTrees ()
	{
//		Refresh ();

		switch (_TreeRowState)
		{
		case TreeRowState.Baby:

			_TreeRowState = TreeRowState.Mid;
			Refresh ();

			break;

		case TreeRowState.Mid:

			_TreeRowState = TreeRowState.Adult;
			Refresh ();

			break;

		case TreeRowState.Adult:

			_TreeRowState = TreeRowState.Baby;
			Refresh ();

			break;

		default:
			Debug.Log("There is a new View add logic here. view name is " + _TreeRowState);
			break;
		}

	}

	public void TreeSwap (int TreeToChange, int TreeDataIndex)
	{
//		Debug.Log (CurrentPokemon._SkillTreeData [TreeDataIndex].Name);
			_NewTreeManager.TreesToRoll [TreeToChange].ChangeDisplayData (	
			TreeDataIndex,
			CurrentPokemon._SkillTreeData [TreeDataIndex]);
//				Debug.Log (TreeToChange+" "+TreeDataIndex);
	}

}

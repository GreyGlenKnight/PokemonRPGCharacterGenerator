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
		
	public static List <T> MakeCopy <T> (this List<T> thisList)
	{
		List <T> returnList = new List <T> ();

		for (int i = 0; i < thisList.Count; i++)
		{
			returnList.Add (thisList [i]);
		}
		return returnList;
	}

	public static void Apply <T> (this List<T> thisList,Action<T> action)
	{
		List<T> tempList = thisList.MakeCopy<T>();

		for (int i = 0; i < tempList.Count; i++)
		{
			action(tempList[i]);
		}
	}

}

public enum SelectionState
{
	Select,
	Roll
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
	public SelectionState _SelectionState;
	public Pokemon CurrentPokemon;
	public TreeRowState TreeRowState;
	public BadgeLevelGenerator _BadgeLevelGenerator;
	public PokemonSheetDisplay _PokemonSheetDisplay;
	public PokeSheetHistoryManager _PokeSheetHistoryManager;


	void Awake()

	{
		if (instance == null)
		{instance = this;}
			
		else  if (instance != this)
		{Destroy (gameObject);}
		DontDestroyOnLoad(gameObject);

		_SelectionState = SelectionState.Roll;
		Pokemon.Breed CharmanderBreed = new Pokemon.Breed (ElementTypes.Fire, ElementTypes.Nothing);
		CharmanderBreed.BreedName = "Charmander";
		CharmanderBreed.BreedStatBlock.Endurance.ThisRawValue = 4;
		CharmanderBreed.BreedStatBlock.Attack.ThisRawValue = 5;
		CharmanderBreed.BreedStatBlock.Defense.ThisRawValue = 4;
		CharmanderBreed.BreedStatBlock.SpecialAttack.ThisRawValue = 5;
		CharmanderBreed.BreedStatBlock.SpecialDefense.ThisRawValue = 4;
		CharmanderBreed.BreedStatBlock.Speed.ThisRawValue = 6;


		CurrentPokemon = new Pokemon (CharmanderBreed);
		CurrentPokemon.Maturity = 0;
		CurrentPokemon.Level = 0;
		CurrentPokemon.Rate = 5;
		CurrentPokemon._StatBlock.EnduranceBonuses.SetRawValue (3);
		CurrentPokemon._StatBlock.AttackBonuses.SetRawValue (1);
		CurrentPokemon._StatBlock.DefenseBonuses.SetRawValue (1);
		CurrentPokemon._StatBlock.SpecialAttackBonuses.SetRawValue (0);
		CurrentPokemon._StatBlock.SpecialDefenseBonuses.SetRawValue (2);
		CurrentPokemon._StatBlock.SpeedBonuses.SetRawValue (0);

		CurrentPokemon.CurrentDamage = 0;
		CurrentPokemon.CurrentStrainLost = 0;

		_NewTreeManager.ChangeDisplayPokemon (CurrentPokemon);
		_PokemonSheetDisplay.ShowNewPokemon (CurrentPokemon, CharmanderBreed);



		CurrentPokemon._TechniquesKnown.Add (Technique.Fire_Blast ());
		CurrentPokemon._TechniquesKnown.Add (Technique.Dragon_Claw ());
		CurrentPokemon._TechniquesKnown.Add (Technique.Metal_Claw ());
		CurrentPokemon._TechniquesKnown.Add (Technique.Sand_Attack ());
		CurrentPokemon._TechniquesKnown.Add (Technique.Fire_Blast ());

		CurrentPokemon._TechniquesActive.Add (Technique.Fire_Blast ());
		CurrentPokemon._TechniquesActive.Add (Technique.Dragon_Claw ());
		CurrentPokemon._TechniquesActive.Add (Technique.Metal_Claw ());
		CurrentPokemon._TechniquesActive.Add (Technique.Sand_Attack ());
		CurrentPokemon._TechniquesActive.Add (Technique.Fire_Blast ());

		for (int i = 0; i < CurrentPokemon._TechniquesKnown.Count; i++) 
		{
			_PokemonSheetDisplay.TechsList [i].ChangeTechniqueDisplay (CurrentPokemon._TechniquesActive [i]);
		}
		_PokeSheetHistoryManager.ChangeDisplay (CurrentPokemon.BonusHistory);
	}

	public void Refresh ()
	{
		_NewTreeManager.Refresh ();
	}

	public void ChangeVisibleTrees ()
	{
		_NewTreeManager.ChangeVisibleTrees ();
	}

	public void TreeSwap (int TreeToChange, int TreeDataIndex)
	{
		_NewTreeManager.TreeSwap (TreeToChange, TreeDataIndex);
	}

}

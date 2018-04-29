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

public class GameManager : MonoBehaviour 

{
	public MaturityManager _MaturityManager;
	public static GameManager instance = null;
	public NewTreeManager _NewTreeManager;
	public SelectionState _SelectionState = SelectionState.Roll;
	public PokemonClass CurrentPokemon;
	
	public List <SkillTree> SkillTrees = new List <SkillTree> (12);
	public BadgeLevelGenerator _BadgeLevelGenerator;
//	public SkillTree TreeGoingOut;
//	public SkillTree TreeGoingIn;


	void Awake()

	{
		
		if (instance == null)
		{instance = this;}
			
		else  if (instance != this)
		{Destroy (gameObject);}
		DontDestroyOnLoad(gameObject);

		CurrentPokemon = new PokemonClass ();

		for (int i = 0; i < SkillTrees.Count; i++) 
		{
			SkillTrees[i].ChangeDisplayData (CurrentPokemon._SkillTreeData[i]);
		}
	}

	public void TreeSwap ()
	{
		List <BonusAtIndex> TempBonuses;
		SkillTreeData DataGoingOut = SkillTrees [0]._TreeData;
		SkillTreeData DataGoingIn = SkillTrees [4]._TreeData;
		TempBonuses = SkillTrees [0].GetRemainingBonuses();
		SkillTrees [0].ChangeDisplayData (DataGoingIn, SkillTrees [4].GetRemainingBonuses());
		SkillTrees [4].ChangeDisplayData (DataGoingOut, TempBonuses);
		Debug.Log ("Swapping Trees");
	}
}

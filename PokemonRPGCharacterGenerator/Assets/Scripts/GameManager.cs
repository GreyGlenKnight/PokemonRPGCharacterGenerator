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
	public MaturityManager _MaturityManager;
	public static GameManager instance = null;
	public NewTreeManager _NewTreeManager;
	public SelectionState _SelectionState = SelectionState.Roll;
	public PokemonClass CurrentPokemon;
	public TreeRowState _TreeRowState;

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
		_TreeRowState = TreeRowState.Baby;
		ChangeVisibleTrees ();
//		for (int i = 0; i < SkillTrees.Count; i++) 
//		{
//			SkillTrees[i].ChangeDisplayData (CurrentPokemon._SkillTreeData[i]);
//		}
	}

	public void Refresh ()
	{
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
		Refresh ();

		switch (_TreeRowState)
		{
		case TreeRowState.Baby:

			_TreeRowState = TreeRowState.Mid;
			break;

		case TreeRowState.Mid:

			_TreeRowState = TreeRowState.Adult;
			break;

		case TreeRowState.Adult:

			_TreeRowState = TreeRowState.Baby;
			break;

		default:
			Debug.Log("There is a new View add logic here. view name is " + _TreeRowState);
			break;
		}

	}

	public void TreeSwap (int TreeToChange, int TreeDataIndex)
	{

		SkillTrees [TreeToChange].ChangeDisplayData (	
			TreeDataIndex,
			CurrentPokemon._SkillTreeData [TreeDataIndex], 
			CurrentPokemon._BonusesRemaining [TreeDataIndex].BonusesRemaining);

	}


	public void TreeSwap ()
	{
//		List <BonusAtIndex> TempBonuses;
//		SkillTreeData DataGoingOut = SkillTrees [0]._TreeData;
//		SkillTreeData DataGoingIn = SkillTrees [4]._TreeData;
//		TempBonuses = SkillTrees [0].GetRemainingBonuses ();
//		SkillTrees [0].ChangeDisplayData (DataGoingIn, SkillTrees [4].GetRemainingBonuses());
//		SkillTrees [4].ChangeDisplayData (DataGoingOut, TempBonuses);
		Debug.Log ("This should be removed");
	}
}

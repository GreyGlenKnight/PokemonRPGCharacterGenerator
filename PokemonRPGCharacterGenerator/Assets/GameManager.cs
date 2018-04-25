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
	List <SkillTreeData> _SkillTreeData = new List <SkillTreeData> ();
	public SkillTree [] SkillTrees = new SkillTree [12];

	void Awake()

	{
		
		if (instance == null)
		{instance = this;}
			
		else  if (instance != this)
		{Destroy (gameObject);}
		DontDestroyOnLoad(gameObject);

		CurrentPokemon = new PokemonClass ();
		_SkillTreeData.Add (new SkillTreeData ("Imp", SkillTreeTier.Tier0));
		_SkillTreeData.Add (new SkillTreeData ("Drake", SkillTreeTier.Tier1));
		_SkillTreeData.Add (new SkillTreeData ("Fire Body 1", SkillTreeTier.Tier1));
		_SkillTreeData.Add (new SkillTreeData ("Claw 1", SkillTreeTier.Tier1));
		_SkillTreeData.Add (new SkillTreeData ("Claw 2", SkillTreeTier.Tier2));
		_SkillTreeData.Add (new SkillTreeData ("Beast", SkillTreeTier.Tier1));
		_SkillTreeData.Add (new SkillTreeData ("Fire Body 2", SkillTreeTier.Tier2));
		_SkillTreeData.Add (new SkillTreeData ("Pyromancer 1", SkillTreeTier.Tier1));
		_SkillTreeData.Add (new SkillTreeData ("Pureblood 2", SkillTreeTier.Tier2));
		_SkillTreeData.Add (new SkillTreeData ("Pureblood 3", SkillTreeTier.Tier3));
		_SkillTreeData.Add (new SkillTreeData ("Fire Body 3", SkillTreeTier.Tier3));
		_SkillTreeData.Add (new SkillTreeData ("Acrobatics 1", SkillTreeTier.Tier1));

		for (int i = 0; i < SkillTrees.Length; i++) 
		{
			SkillTrees[i].ChangeDisplayData (_SkillTreeData [i]);
		}
	}
}

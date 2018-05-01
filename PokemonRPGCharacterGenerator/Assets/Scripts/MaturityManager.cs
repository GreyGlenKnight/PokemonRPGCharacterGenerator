using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class MaturityManager : MonoBehaviour 
{
	public int [] BreakTree = new int[] 
	{
		0,1,4,7
	} ;

	public int [] SwitchTree = new int[]
	{
		9,16,	21,24,	30,36
	} ;
		
	public int [] ActiveTree = new int[] 
	{
		0,3,6,17
	} ;

	public int [] BonusLevels = new int[] 
	{
		2,5,8,11,14,17,20,23,26,29,32,35,38
	} ;

	public PokemonClass Pokemon;
	public List <MaturityRank> MaturityBonusList = new List <MaturityRank> ();
	public int CurrentMaturity;
	public float CurrentMaturityWithRemainder;
	public string [] Maturity = new string []
	{
		"Gain and Break Baby Skill, Birth Ability",
		"Break Adult Tree, Nature",
		"Bonus Level 1",
		"Gain Adult Tree, Gain Ability Slot 2",
		"Break Skill 1, STAB Bonus +1",
		"Bonus Level 2",
		"Gain Skill 1, Special Training Slot 1",
		"Break Skill 1, Enhancer Slot 1",
		"Bonus Level 3",
		"Trade Skill 1, Attribute Bonus 2",
		"Break Skill 2, STAB Bonus 2",
		"Bonus Level 4",
		"Special Training Slot 2",
		"Break Skill 1, Ability Slot 3",
		"Bonus Level 5",
		"Break Skill 1, Enhancer Slot 2",
		"Trade Skill 1, STAB Bonus 3",
		"Bonus Level 6",
		"Gain Skill 1, Break Skill 3",
		"Break Skill 2",
		"Bonus Level 7",
		"Trade Skill 2, Break Skill 3",
		"STAB Bonus 4",
		"Bonus Level 8",
		"Trade Skill 2, Attribute Bonus 3",
		"Special Training Slot 3",
		"Bonus Level 9",
		"Break Skill 3",
		"STAB Bonus 5",
		"Bonus Level 10",
		"Trade Skill 3",
		"Enhancer Slot 3",
		"Bonus Level 11",
		"Break Skill 3",
		"STAB Bonus 6",
		"Bonus Level 12",
		"Trade Skill 3",
		"Attribute Bonus 4",
		"Bonus Level 13",
		"Enhancer Bonus 4",
		"STAB Bonus 7"};
	public List <int> HighestMaturity = new List <int> ();
	public int HMItem1;

	void Awake ()
	{
		for (int i = 0; i < 41; i++) 
		{
			MaturityBonusList.Add (new MaturityRank (i, Maturity [i]));
		}
	}

	public void EliminateMaturityBonus ()
	{
		
		if (Pokemon == null)
		{
			Pokemon = new PokemonClass ();
		}
//		CurrentMaturity++;

		IMaturityBonus bonus = MaturityRank.GetBonusAtLevel (CurrentMaturity);
		Pokemon.ApplyMaturityBonus (bonus, CurrentMaturity);


		for (int i = 0; i < BreakTree.Length; i++) 
		{
			if (CurrentMaturity == BreakTree [i])
			{
				GameManager.instance._NewTreeManager.TreesToRoll [i].ChangeState(SkillTreeState.Inactive);
			}
		}

		for (int i = 0; i < ActiveTree.Length; i++) {
			if (CurrentMaturity == ActiveTree [i]) {
				GameManager.instance._NewTreeManager.TreesToRoll [i].ChangeState (SkillTreeState.Active);
			}
		}
		SwitchTrees ();
	}



	public void MaturityCheck ()
	{
		CurrentMaturityWithRemainder = GameManager.instance.CurrentPokemon.CurrentMaturity;
		CurrentMaturity = GameManager.instance.CurrentPokemon.CurrentMaturityInt;
		HMItem1 = MaturityBonusList [0].Maturity;

		if (CurrentMaturity > 40) 
		{return;}

		if (HMItem1 < CurrentMaturity)
		{
			EliminateMaturityBonus ();
		}
	}

	public void SwitchTrees ()
	{
		for (int i = 0; i < SwitchTree.Length; i++) 
		{
			if (CurrentMaturityWithRemainder == SwitchTree [i]) 
			{
				GameManager.instance.CurrentPokemon.PokemonTreeSwap ();
				GameManager.instance.Refresh ();
					//We need to know which items on the list are matching, that will tell us the tier.
					//Also we can swap different indices on the list instead of the first.
					Debug.Log ("This should not come up like 3 times per level");
				}
		}
	}

	public void UnlockTrees ()
	{
		for (int i = 0; i < BreakTree.Length; i++) 
		{
			if (CurrentMaturity >= BreakTree [i])
			{
				GameManager.instance._NewTreeManager.TreesToRoll [i].ChangeState(SkillTreeState.Inactive);
//				GameManager.instance._NewTreeManager.TreesToRoll [i].TreeDisplay.TreeColorUpdate ();
//				Debug.Log ("Should evaluate treecolorupdate at this location");
			}
		}

		for (int i = 0; i < ActiveTree.Length; i++) 
		{
			if (CurrentMaturity >= ActiveTree [i]) 
			{
				GameManager.instance._NewTreeManager.TreesToRoll [i].ChangeState(SkillTreeState.Active);
			}
		}
	}
}
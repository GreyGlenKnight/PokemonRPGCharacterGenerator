using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class NewTreeManager : MonoBehaviour 
{
//	public bool IsTreeFull = false;
	public const int NUMBER_OF_TREES = 4;
	public BonusAtIndex [] TreeRolls = new BonusAtIndex [NUMBER_OF_TREES];
	public const int BONUSES_ON_TREE = 12;

	public List <SkillTreeData> TreesToRoll = new List <SkillTreeData> ();
	public List <SkillTreePaneDisplay> TreeDisplays = new List <SkillTreePaneDisplay> ();
	public List <int> Bonuses = new List <int> ();
	public List <int> TempRoll = new List <int> ();

	private Pokemon _CurrentPokemon;
	public TreeRowState _TreeRowState;
	public InterruptDialog _InterruptDialog;
	public PokeSheetTreeManager _TreeScene;


	public void OnBreakTree (object Caller, EventArgs E)
	{
		Refresh ();
 	}

	public void OnActivateTree (object Caller, EventArgs E)
	{
		Refresh ();
	}

	public void OnTradeSkill (object Caller, EventArgs E)
	{
		Refresh ();
	}

	public void OnSelectOption (object Caller, EventArgs E)
	{
		Refresh ();
	}
		
	public void OnSelectTree1 ()
	{
		TreesToRoll [0].OnManualSelectClick ();
		_InterruptDialog.gameObject.SetActive (false);
		_TreeScene.gameObject.SetActive (true);
		Refresh ();	
	}

	public void OnSelectTree2 ()
	{
		TreesToRoll [1].OnManualSelectClick ();
		_InterruptDialog.gameObject.SetActive (false);
		_TreeScene.gameObject.SetActive (true);
		Refresh ();	
	}

	public void OnSelectTree3 ()
	{
		TreesToRoll [2].OnManualSelectClick ();
		_InterruptDialog.gameObject.SetActive (false);
		_TreeScene.gameObject.SetActive (true);
		Refresh ();	
	}

	public void OnSelectTree4 ()
	{
		TreesToRoll [3].OnManualSelectClick ();
		_InterruptDialog.gameObject.SetActive (false);
		_TreeScene.gameObject.SetActive (true);
		Refresh ();	
	}

	public void OnAddXPClick ()
	{
		_CurrentPokemon.AddXP ();
		GameManager.instance._BadgeLevelGenerator._BadgeLevelDisplay.UpdateDisplay (_CurrentPokemon);
	}

//	public Pokemon CopyCurrentPokemon {get {return new Pokemon (_CurrentPokemon);}}
		
	public void ChangeDisplayPokemon (Pokemon ToDisplay)
	{
		_TreeRowState = TreeRowState.Baby;
		_CurrentPokemon = ToDisplay;
		ToDisplay.OnBreakTree += OnBreakTree;
		ToDisplay.OnActivateTree += OnActivateTree;
		ToDisplay.OnTradeSkill += OnTradeSkill;
	}

	public void Refresh ()
	{
		GameManager.instance._BadgeLevelGenerator._BadgeLevelDisplay.UpdateDisplay (_CurrentPokemon);

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
		if (TreeDisplays.Count <= TreeToChange) 
		{
			return;
		}

		if (_CurrentPokemon._SkillTreeData.Count <= TreeDataIndex) 
		{
			//Not really sure what this does?
			//I guess it returns a safe null display state?
			TreeDisplays [TreeToChange].ChangeDisplayData (null);
			return;
		}

		TreeDisplays [TreeToChange].ChangeDisplayData (_CurrentPokemon._SkillTreeData [TreeDataIndex]);
	}


	public void OnCallTreeRoll ()
	{
		if (_CurrentPokemon.SpendXP () == false) 
		{
			Debug.Log ("NewTreeManager XP Spend Fail");
			return;
		}

		Bonuses.Clear ();
		TreesToRoll.Clear ();

		for (int i = 0; i < _CurrentPokemon._SkillTreeData.Count; i++) 
		{
			SkillTreeData Temp = _CurrentPokemon._SkillTreeData [i].GetTreeIfActive ();
			if (Temp != null) 
			{
				TreesToRoll.Add (Temp);
			}
		}
			
		List <ILevelUpOption> TempOptions = new List <ILevelUpOption> ();

		for (int i = 0; i < TreesToRoll.Count; i++) 
		{
			if (TreesToRoll [i]._BonusesRemaining.Bonuses.Count > 0 |
					TreesToRoll [i].GetCurrentSelectedBonus () != BonusAtIndex.None) 
			{
				TreesToRoll[i].RollTheList ();
				Bonuses.Add ((int)TreesToRoll [i].GetCurrentSelectedBonus ());
				TempOptions.Add (TreesToRoll [i].GetBonusForIndex ((BonusAtIndex)Bonuses [i]));
			}
		}
		try 
		{
			Debug.Log ("In try block");
			_InterruptDialog.DisplayOptionsList (TempOptions, 
				TreesToRoll);
		}
		catch (InvalidBonusesException e)
		{
			Debug.Log (e.BonusesLength +", "+ e.TreesLength);
		}

	}


	public void OnAutoSelectClick ()

	{
		for (int i = 0; i < TreesToRoll.Count; i++) 
		{
			TreeRolls [i] = TreesToRoll [i].GetCurrentSelectedBonus ();
		}

		CheckForBonusType (BonusAtIndex.StatUp);
		CheckForBonusType (BonusAtIndex.MoveMod);
		CheckForBonusType (BonusAtIndex.Skill1);
		CheckForBonusType (BonusAtIndex.Skill2);
		CheckForBonusType (BonusAtIndex.Skill3);
		CheckForBonusType (BonusAtIndex.Skill4);
		CheckForBonusType (BonusAtIndex.SkillUp);
		CheckForBonusType (BonusAtIndex.Ability);
		CheckForBonusType (BonusAtIndex.Endurance);
		CheckForBonusType (BonusAtIndex.Maturity);
		CheckForBonusType (BonusAtIndex.TreeUp);
		CheckForBonusType (BonusAtIndex.CrossTree);
	}

	public void ChooseBonus ()
	{
		if (TempRoll.Count > 0) 
		{
			TempRoll.Shuffle ();
			TreesToRoll [TempRoll [0]].OnSelected ();
			TempRoll.Clear ();
			{return;}
		}
	}

	public void CheckForBonusType (BonusAtIndex _Bonus)
	{
		for (int i = 0; i < TreesToRoll.Count; i++) 
		{
			if (TreeRolls [i] == _Bonus) 
			{
				TempRoll.Add (i);
			}
		}
		ChooseBonus ();
	}
}
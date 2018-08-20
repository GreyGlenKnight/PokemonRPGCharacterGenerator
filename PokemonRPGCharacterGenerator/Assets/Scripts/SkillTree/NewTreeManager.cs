using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class NewTreeManager : MonoBehaviour 
{
	public const int NUMBER_OF_TREES = 4;
	public List <ILevelUpOption> TreeRolls = new List <ILevelUpOption> ();
	public const int BONUSES_ON_TREE = 12;

	public List <SkillTree> TreesToRoll = new List <SkillTree> ();
	public List <SkillTreePaneDisplay> TreeDisplays = new List <SkillTreePaneDisplay> ();
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

	public void SceneUpdate ()
	{
		_InterruptDialog.gameObject.SetActive (false);
		_TreeScene.gameObject.SetActive (true);
		Refresh ();	
	}
		
	public void OnSelectTree1 ()
	{
		TreesToRoll [0].OnManualSelectClick ((LevelUpBonus) TreeRolls [0]);
		SceneUpdate ();
	}

	public void OnSelectTree2 ()
	{
		TreesToRoll [1].OnManualSelectClick ((LevelUpBonus) TreeRolls [1]);
		SceneUpdate ();
	}

	public void OnSelectTree3 ()
	{
		TreesToRoll [2].OnManualSelectClick ((LevelUpBonus) TreeRolls [2]);
		SceneUpdate ();
	}

	public void OnSelectTree4 ()
	{
		TreesToRoll [3].OnManualSelectClick ((LevelUpBonus) TreeRolls [3]);
		SceneUpdate ();
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
		TreesToRoll = ToDisplay._SkillTreeBlock._SkillTrees;
		ToDisplay.OnBreakTree += OnBreakTree;
		ToDisplay.OnActivateTree += OnActivateTree;
		ToDisplay.OnTradeSkill += OnTradeSkill;
		Refresh ();
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

		if (_CurrentPokemon._SkillTreeBlock._SkillTrees.Count <= TreeDataIndex) 
		{
			TreeDisplays [TreeToChange].ChangeDisplayData (null);
			return;
		}

		TreeDisplays [TreeToChange].ChangeDisplayData (_CurrentPokemon._SkillTreeBlock._SkillTrees [TreeDataIndex]);
	}


	public void OnCallTreeRoll ()
	{
		TreeRolls = _CurrentPokemon._SkillTreeBlock.RollOnTrees ();
//		Debug.Log (Temp [0].ToString());
		if (TreeRolls == null)
			{return;}
//		TreesToRoll = Temp;
		_InterruptDialog.DisplayOptionsList (TreeRolls);
	}


	public void OnAutoSelectClick ()

	{
		TreeRolls = _CurrentPokemon._SkillTreeBlock.RollOnTrees ();

		CheckForBonusType (BonusAtIndex.StatUp);
		CheckForBonusType (BonusAtIndex.MoveMod);
		CheckForBonusType (BonusAtIndex.Technique);
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
			int RollToUse = TempRoll [0];
			TreesToRoll [RollToUse].OnSelected ((LevelUpBonus)TreeRolls [RollToUse]);
			TempRoll.Clear ();
			{return;}
		}
	}

	public void CheckForBonusType (BonusAtIndex _Bonus)
	{
		for (int i = 0; i < TreeRolls.Count; i++) 
		{
			if (TreeRolls [i].TypeOfBonus == _Bonus) 
			{
				TempRoll.Add (i);
			}
		}
		ChooseBonus ();
	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class NewTreeManager : MonoBehaviour 
{
//	public bool IsTreeFull = false;
	public List <SkillTree> TreesToRoll = new List <SkillTree> ();
	public List <int> Bonuses = new List <int> ();
	private Pokemon _CurrentPokemon;
	public TreeRowState _TreeRowState;

	public void OnBreakTree (object Caller, EventArgs E)
	{
//		Pokemon ToDisplay = (Pokemon) Caller;
		Refresh ();
		Debug.Log ("It got called");
 	}

	public void OnActivateTree (object Caller, EventArgs E)
	{
		Refresh ();
	}


	public void OnCallTreeRoll ()
	{
//		Debug.Log (TreesToRoll.Count);
		if (XPManager.SpendXP () == false) 
		{
			Debug.Log ("NewTreeManager XP Spend Fail");
			return;
		}
		for (int i = 0; i < TreesToRoll.Count; i++) 
		{
			TreesToRoll[i].RollOnTree ();
		}
	}

	public void ChangeDisplayPokemon (Pokemon ToDisplay)
	{
		_TreeRowState = TreeRowState.Baby;
		_CurrentPokemon = ToDisplay;
		ToDisplay.BreakTree += OnBreakTree;
		ToDisplay.ActivateTree += OnActivateTree;
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
		if (TreesToRoll.Count <= TreeToChange) 
		{
			return;
		}

		if (_CurrentPokemon._SkillTreeData.Count <= TreeDataIndex) 
		{
			TreesToRoll [TreeToChange].ChangeDisplayData (TreeDataIndex, null);
			return;
		}
		Debug.Log (TreeToChange+TreeDataIndex);
		Debug.Log (TreesToRoll.Count);
		Debug.Log (_CurrentPokemon._SkillTreeData.Count);

			TreesToRoll [TreeToChange].ChangeDisplayData (
				TreeDataIndex,
				_CurrentPokemon._SkillTreeData [TreeDataIndex]);
	}
}
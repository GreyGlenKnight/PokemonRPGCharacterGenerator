using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class SkillTree : MonoBehaviour 
{
	public int CurrentTreeIndex = 0;
	public const int BONUSES_ON_TREE = 12;
	public SkillTreeDisplay TreeDisplay;
	private List<BonusAtIndex> RemainingBonuses = new List<BonusAtIndex> ();
	public bool IsTreeFull = false;
	public bool IsInit = false;
	public string Name;
	public SkillTreeData _TreeData;


	public List <BonusAtIndex> GetRemainingBonuses ()
	{
		return RemainingBonuses;
	}

	public void ChangeDisplayData (
		int TreeIndexToDisplay,
		SkillTreeData NewTreeData)
//		,List <BonusAtIndex> TempRemainingBonuses)
	{
//		Debug.Log (NewTreeData.Name);
		CurrentTreeIndex = TreeIndexToDisplay;
//		Debug.Log ("2 Parameters");
//		string TempString = "2 Param";
//		for (int i = 0; i < NewTreeData._BonusesAcquired.BonusesRemaining.Count; i++) 
//		{
//			TempString += ","+ NewTreeData._BonusesAcquired.BonusesRemaining [i];
//		}
//		Debug.Log (TempString);
//		RemainingBonuses = NewTreeData._BonusesAcquired.BonusesRemaining;
		_TreeData = NewTreeData;
		if (NewTreeData != null) 
		{
			Name = NewTreeData.Name;
		}
		TreeDisplay.TreeColorUpdate (_TreeData);
	}

//	public void ChangeDisplayData (
//		int TreeIndexToDisplay,
//		SkillTreeData NewTreeData) 
//	{
//		CurrentTreeIndex = TreeIndexToDisplay;
//		Debug.Log ("1 Parameter");
//		string TempString = "1 Param";
//		for (int i = 0; i < RemainingBonuses.Count; i++) 
//		{
//			TempString += ","+ RemainingBonuses [i];
//		}
////		Debug.Log (TempString);
//		if (IsInit == false) 
//		{
//			ResetBonuses ();
//		}
//		_TreeData = NewTreeData;
//		Name = NewTreeData.Name;
//		TreeDisplay.TreeColorUpdate (_TreeData.CurrentState, Name, _TreeData.Tier, 
//			RemainingBonuses);
//	}

//	public void ChangeState (SkillTreeState NewState)
//	{
//		_TreeData.ChangeState (NewState);
//
//		if (_TreeData == null) 
//		{
//			return;
//		}
//
//		TreeDisplay.TreeColorUpdate (_TreeData.CurrentState, Name, _TreeData.Tier, RemainingBonuses);
//	}

	public BonusAtIndex GetCurrentSelectedBonus ()
	{
		if (_TreeData == null) 
		{
			return BonusAtIndex.None;
		}
		if (_TreeData.CurrentState != SkillTreeState.Active) 
		{
			return BonusAtIndex.None;
		}

		if (RemainingBonuses.Count == 0) 
		{
			return BonusAtIndex.None;
		}
		return (BonusAtIndex) RemainingBonuses [0];
	}

	public void RollOnTree ()

	{
		RollTheList ();
	}

	public void RollTheList ()
	{
		if (_TreeData == null) 
		{
			return;
		}
		if (_TreeData.CurrentState != SkillTreeState.Active)
		{
//			Debug.Log ("Tree inactive!");
			TreeDisplay.DisplayBonusString ("N/A");
			return;
		}

		RemainingBonuses = GameManager.instance.CurrentPokemon._SkillTreeData [CurrentTreeIndex]._BonusesAcquired.BonusesRemaining; 

		if (RemainingBonuses.Count > 0) 
		{
			RemainingBonuses.Shuffle ();
			Debug.Log (CurrentTreeIndex);
			TreeDisplay.DisplayBonusString (((int) RemainingBonuses [0] +1).ToString());
		} 
		else 
		{
			
			TreeDisplay.DisplayBonusString ("~");
		}
	}

	public void OnSelected ()
	{
		if (_TreeData == null) 
		{
			Debug.Log ("Selected Tree Null!");
			return;
		}
		if (GameManager.instance._SelectionState == SelectionState.Roll) 
		{
			return;
		}

		if (_TreeData.CurrentState != SkillTreeState.Active) 
		{
			Debug.Log ("Selected Tree Inactive!");
			return;
		}

		if (RemainingBonuses.Count == 0) 
		{
			return;
		}
//		GameManager.instance.CurrentPokemon._BonusesRemaining [CurrentTreeIndex].BonusesRemaining.RemoveAt (0);

		TreeDisplay.CheckSelectedBonus ((int) RemainingBonuses [0]);
		RemainingBonuses.RemoveAt (0);
		GameManager.instance._SelectionState = SelectionState.Roll;
	}

	public void OnManualSelectClick ()
	{
		if (GameManager.instance._SelectionState == SelectionState.Select)
		{
			OnSelected ();
			GameManager.instance.CurrentPokemon.LevelUp ();
		}
	}
		
	public void ResetBonuses ()
	{ 
		for (int i = 0; i < BONUSES_ON_TREE; i++) 
		{
			RemainingBonuses.Add ((BonusAtIndex)i);
		}
		IsInit = true;
	}

	public void Awake ()
	{
//		Debug.Log ("");
		TreeDisplay = GetComponent<SkillTreeDisplay> ();
		ResetBonuses ();
//		ChangeState (SkillTreeState.Locked);
//		Debug.Log ("Awake skilltree");
	}
}
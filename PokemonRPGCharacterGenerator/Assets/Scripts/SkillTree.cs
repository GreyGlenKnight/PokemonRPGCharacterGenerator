using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public enum SkillTreeState
{
	Active, Inactive, Locked
}

public class SkillTree : MonoBehaviour 
{
	
	public const int BONUSES_ON_TREE = 12;
	public SkillTreeDisplay TreeDisplay;
	private List<BonusAtIndex> RemainingBonuses = new List<BonusAtIndex> ();
//	public int BonusIndex;
	public bool IsTreeFull = false;
	public bool IsInit = false;
	private SkillTreeState _State;
	public string Name;
	public SkillTreeData _TreeData;

	//SkillTreeState should really be private?

	public List <BonusAtIndex> GetRemainingBonuses ()
	{
		return RemainingBonuses;
	}

	public void ChangeDisplayData (
        SkillTreeData NewTreeData, 
		List <BonusAtIndex> TempRemainingBonuses)
	{
		Debug.Log ("2 Parameters");
		string TempString = "2 Param";
		for (int i = 0; i < TempRemainingBonuses.Count; i++) 
		{
			TempString += ","+ TempRemainingBonuses [i];
		}
		Debug.Log (TempString);
		RemainingBonuses = TempRemainingBonuses;
		_TreeData = NewTreeData;
		Name = NewTreeData.Name;
		TreeDisplay.TreeColorUpdate (_State, Name, _TreeData.Tier, 
			TempRemainingBonuses);
		
	}

	public void ChangeDisplayData (SkillTreeData NewTreeData) 
	{
		Debug.Log ("1 Parameter");
		string TempString = "1 Param";
		for (int i = 0; i < RemainingBonuses.Count; i++) 
		{
			TempString += ","+ RemainingBonuses [i];
		}
		Debug.Log (TempString);
		if (IsInit == false) 
		{
			ResetBonuses ();
		}
		_TreeData = NewTreeData;
		Name = NewTreeData.Name;
		TreeDisplay.TreeColorUpdate (_State, Name, _TreeData.Tier, 
			RemainingBonuses);
	}

	public void ChangeState (SkillTreeState NewState)
	{
		_State = NewState;

		if (_TreeData == null) 
		{
			return;
		}

		TreeDisplay.TreeColorUpdate (_State, Name, _TreeData.Tier, RemainingBonuses);

	}

	public BonusAtIndex GetCurrentSelectedBonus ()
	{
		if (_State != SkillTreeState.Active) 
		{
			return BonusAtIndex.None;
		}

		if (RemainingBonuses.Count == 0) 
		{
			return BonusAtIndex.None;
		}
		return (BonusAtIndex) RemainingBonuses [0];
	}

	public void RollOnTree()

	{
		RollTheList ();
	}

	public void RollTheList ()
	{
		if (_State != SkillTreeState.Active)
		{
//			Debug.Log ("Tree inactive!");
			TreeDisplay.DisplayBonusString ("N/A");
			return;
		}
		if (RemainingBonuses.Count > 0) 
		{
			RemainingBonuses.Shuffle ();
			TreeDisplay.DisplayBonusString (((int) RemainingBonuses [0] +1).ToString());
		} 
		else 
		{
			TreeDisplay.DisplayBonusString ("~");
		}
	}

	public void OnSelected ()
	{
		if (GameManager.instance._SelectionState == SelectionState.Roll) 
		{
			return;
		}

		if (_State != SkillTreeState.Active) 
		{
			Debug.Log ("Selected Tree Inactive!");
			return;
		}

		if (RemainingBonuses.Count == 0) 
		{
			return;
		}

		TreeDisplay.CheckSelectedBonus ((int) RemainingBonuses [0]);
		RemainingBonuses.RemoveAt (0);
		GameManager.instance._SelectionState = SelectionState.Roll;
	}

	public void OnManualSelectClick ()
	{
		OnSelected ();
		GameManager.instance._MaturityManager.MaturityCheck ();

	}
		
	public void ResetBonuses ()
	{ 
		for (int i = 0; i < BONUSES_ON_TREE; i++) 
		{
			RemainingBonuses.Add ((BonusAtIndex)i);
		}
		IsInit = true;
//		RemainingBonuses.Shuffle ();
	}
	public void Start ()
	{
		GameManager.instance._MaturityManager.UnlockTrees ();
//		GameManager.instance._MaturityManager.SwitchTrees ();

	}
		
	public void Awake()
	{
		TreeDisplay = GetComponent<SkillTreeDisplay> ();
		ResetBonuses ();
		ChangeState (SkillTreeState.Locked);
	}
}
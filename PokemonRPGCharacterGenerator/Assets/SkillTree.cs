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
	List<BonusAtIndex> RemainingBonuses = new List<BonusAtIndex> ();
//	public int BonusIndex;
	public bool IsTreeFull = false;
	private SkillTreeState State;

	public void ChangeState(SkillTreeState NewState)
	{
		State = NewState;

		//For Display purposes, call stuff here

	}

	public BonusAtIndex GetCurrentSelectedBonus ()
	{
		if (State != SkillTreeState.Active) 
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
		if (State != SkillTreeState.Active)
		{
			Debug.Log ("Tree inactive!");
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

		if (State != SkillTreeState.Active) 
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
		GameManager.instance._MaturityManager.MaturityCheck ();
	}

	public void OnManualSelectClick ()
	{
		OnSelected ();
	}
		
	public void ResetBonuses ()
	{ 
		for (int i = 0; i < BONUSES_ON_TREE; i++) 
		{
			RemainingBonuses.Add ((BonusAtIndex)i);
		}
//		RemainingBonuses.Shuffle ();
	}
	public void Start ()
	{
		GameManager.instance._MaturityManager.UnlockTrees ();
	}
		
	public void Awake()
	{
		TreeDisplay = GetComponent<SkillTreeDisplay> ();
		ResetBonuses ();
		ChangeState (SkillTreeState.Locked);
	}
}
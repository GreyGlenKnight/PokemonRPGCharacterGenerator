using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreesView : MonoBehaviour 
{
//	public List <SkillTreeDisplay> _SkillTreeDisplayList = new List <SkillTreeDisplay> (4);
	public const int NUMBER_OF_TREES = 4;
//	public BonusAtIndex [] TreeRolls = new BonusAtIndex [NUMBER_OF_TREES];
//	public SkillTree [] ActiveRolls = new SkillTree[NUMBER_OF_TREES];
	public SkillTreePaneDisplay [] ActiveRolls = new SkillTreePaneDisplay[NUMBER_OF_TREES]; 
	public SkillTreeData [] ActiveTreeData = new SkillTreeData [NUMBER_OF_TREES];
//	public bool TreeFull;
//	public List <int> TempRoll = new List <int> ();

//	public int CurrentTreeIndex = 0;
//	public const int BONUSES_ON_TREE = 12;
	//	public SkillTreeDisplay TreeDisplay;

//	public void Awake ()
//	{
//		TreeDisplay = GetComponent<SkillTreeDisplay> ();
//		ResetBonuses ();
//	}

//	public void OnAutoSelectClick ()
//
//	{
//		for (int i = 0; i < NUMBER_OF_TREES; i++) 
//		{
//			TreeRolls [i] = ActiveTreeData [i].GetCurrentSelectedBonus ();
//			//GetCurrentSelectedBonus returns RemainingBonuses [0]
//		}
//
//		CheckForBonusType (BonusAtIndex.StatUp);
//		CheckForBonusType (BonusAtIndex.MoveMod);
//		CheckForBonusType (BonusAtIndex.Skill1);
//		CheckForBonusType (BonusAtIndex.Skill2);
//		CheckForBonusType (BonusAtIndex.Skill3);
//		CheckForBonusType (BonusAtIndex.Skill4);
//		CheckForBonusType (BonusAtIndex.SkillUp);
//		CheckForBonusType (BonusAtIndex.Ability);
//		CheckForBonusType (BonusAtIndex.Endurance);
//		CheckForBonusType (BonusAtIndex.Maturity);
//		CheckForBonusType (BonusAtIndex.TreeUp);
//		CheckForBonusType (BonusAtIndex.CrossTree);
//	}
//		
//	public void ChooseBonus ()
//	{
//	if (TempRoll.Count > 0) 
//	{
//		TempRoll.Shuffle ();
//		ActiveTreeData [TempRoll [0]].OnSelected ();
//		TempRoll.Clear ();
//		{return;}
//	}
//	}
//
//	public void CheckForBonusType (BonusAtIndex _Bonus)
//	{
//		for (int i = 0; i < NUMBER_OF_TREES; i++) 
//		{
//			if (TreeRolls [i] == _Bonus) 
//			{
//				TempRoll.Add (i);
//			}
//		}
//		ChooseBonus ();
//	}
}
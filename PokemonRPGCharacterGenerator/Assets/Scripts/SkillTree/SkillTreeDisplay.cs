using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class SkillTreeDisplay : MonoBehaviour 
{
	public Toggle[] options = new Toggle[12];
	public Text LastRollText;
	public Image TreeBG;
	public Text TreeNameText;
	public static Color Tier0Color = Color.gray;
	public static Color Tier1Color = Color.cyan;
	public static Color Tier2Color = Color.green;
	public static Color Tier3Color = Color.yellow;
	public static Color LockTreeColor = Color.clear;
//	public static Color InactiveColor = new Color (0f, 0f, 0f, .5f);


//	public void TreeColorUpdate ( 
//		SkillTreeState state,
//		SkillTreeTier tier)
//	{
//		TreeBG.color = LockTreeColor;
//
//		if (state != SkillTreeState.Locked)
//		{
//
//			if (tier == SkillTreeTier.Tier0) 
//			{TreeBG.color = Tier0Color;}
//
//			if (tier == SkillTreeTier.Tier1) 
//			{TreeBG.color = Tier1Color;}
//
//			if (tier == SkillTreeTier.Tier2) 
//			{TreeBG.color = Tier2Color;}
//
//			if (tier == SkillTreeTier.Tier3) 
//			{TreeBG.color = Tier3Color;}
//		}
//	}


	public void TreeColorUpdate (SkillTreeData ToDisplay)
	{
		TreeBG.color = LockTreeColor;

		if (ToDisplay == null)
		{
			TreeNameText.text = "";
			for (int i = 0; i < 12; i++)
			{
			options [i].isOn = false;
			}
			return;
		}

		TreeNameText.text = ToDisplay.Name;

		for (int i = 0; i < 12; i++)
		{
			CheckSelectedBonus (i);
			if (ToDisplay._BonusesAcquired.BonusesRemaining.Contains ((BonusAtIndex) i))
			{
//				Debug.Log (i);
				options [i].isOn = false;
			}
		}

		if (ToDisplay.CurrentState == SkillTreeState.Active)
		{

			if (ToDisplay.Tier == SkillTreeTier.Tier0) 
			{TreeBG.color = Tier0Color;}

			if (ToDisplay.Tier == SkillTreeTier.Tier1) 
			{TreeBG.color = Tier1Color;}

			if (ToDisplay.Tier == SkillTreeTier.Tier2) 
			{TreeBG.color = Tier2Color;}

			if (ToDisplay.Tier == SkillTreeTier.Tier3) 
			{TreeBG.color = Tier3Color;}
		}

		if (ToDisplay.CurrentState == SkillTreeState.Inactive)
		{

			if (ToDisplay.Tier == SkillTreeTier.Tier0) 
			{
				Color ToSet = Tier0Color;
				ToSet.a = 0.5f;
				TreeBG.color = ToSet;
			}

			if (ToDisplay.Tier == SkillTreeTier.Tier1) 
			{
//				Debug.Log ("Color Set");
				Color ToSet = Tier1Color;
				ToSet.a = 0.5f;
				TreeBG.color = ToSet;
			}

			if (ToDisplay.Tier == SkillTreeTier.Tier2) 
			{
				Color ToSet = Tier2Color;
				ToSet.a = 0.5f;
				TreeBG.color = ToSet;
			}

			if (ToDisplay.Tier == SkillTreeTier.Tier3) 
			{
				Color ToSet = Tier3Color;
				ToSet.a = 0.5f;
				TreeBG.color = ToSet;
			}
		}
	}

	public void CheckSelectedBonus (int BonusIndex)
	{
		options [BonusIndex].isOn = true;
	}

	public void DisplayBonusString (string ToDisplay)
	{
		LastRollText.text = ToDisplay;
	}

	void Awake ()
	{

	}
}

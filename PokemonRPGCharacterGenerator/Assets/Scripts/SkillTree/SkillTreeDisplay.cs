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
				options [i].isOn = false;
			}
		}

		if (ToDisplay.CurrentState == SkillTreeState.Active)
		{
			TreeBG.color = TypeColors.GetColorForTier (ToDisplay.Tier);
		}

		if (ToDisplay.CurrentState == SkillTreeState.Inactive)
		{
			Color ToSet = TypeColors.GetColorForTier (ToDisplay.Tier);
			ToSet.a = 0.5f;
			TreeBG.color = ToSet;
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

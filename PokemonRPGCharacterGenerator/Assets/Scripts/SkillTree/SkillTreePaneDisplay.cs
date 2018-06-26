using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class SkillTreePaneDisplay : MonoBehaviour 
{
	public Toggle[] Options = new Toggle[12];
	public Text[] OptionText = new Text[12];
	public Image TreeBG;
	public Text TreeNameText;
	public SkillTreeData _TreeToDisplay;
	public static Color Tier0Color = Color.gray;
	public static Color Tier1Color = Color.cyan;
	public static Color Tier2Color = Color.green;
	public static Color Tier3Color = Color.yellow;
	public static Color LockTreeColor = Color.clear;
	

	public void ChangeDisplayData (SkillTreeData NewTreeData)
	{
		_TreeToDisplay = NewTreeData;
		DisplayTree (_TreeToDisplay);
	}

	public void DisplayTree (SkillTreeData ToDisplay)
	{
		TreeBG.color = LockTreeColor;

		if (ToDisplay == null)
		{
			TreeNameText.text = "";
			for (int i = 0; i < Options.Length; i++)
			{
				OptionText [i].text = "";
				OptionText [i].color = Color.black;

			Options [i].isOn = false;
//			OptionText [i].color = Color.black;
			}
			return;
		}

		TreeNameText.text = ToDisplay.Name;

		for (int i = 0; i < Options.Length; i++)
		{
			OptionText [i].text = _TreeToDisplay.GetBonusForIndex ((BonusAtIndex)i).BonusName;
			OptionText [i].color = Color.black;
			Options [i].isOn = false;

			if (ToDisplay._BonusesAcquired.Bonuses.Contains ((BonusAtIndex) i))
			{
				CheckSelectedBonus (i);
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
		Options [BonusIndex].isOn = true;
		Color ToSet = Color.black;
		ToSet.a = 0.5f;
		OptionText [BonusIndex].color = ToSet;
	}

	public void CheckSelectedBonus (BonusAtIndex BonusIndex)
	{
		CheckSelectedBonus ((int) BonusIndex);
	}
		
}

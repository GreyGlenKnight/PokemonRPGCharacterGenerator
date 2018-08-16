using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class SkillTreeLineDisplay : MonoBehaviour 
{
	public Toggle BonusToggle;
	public Text BonusText;
	public Image BonusBG;
	public LevelUpBonus BonusToDisplay;

	public static Color Tier0Color = Color.gray;
	public static Color Tier1Color = Color.cyan;
	public static Color Tier2Color = Color.green;
	public static Color Tier3Color = Color.yellow;
	public static Color LockTreeColor = Color.clear;


	public void ChangeDisplayData (LevelUpBonus NewBonus)
	{
		if (NewBonus == null)
		{
			BonusBG.color = LockTreeColor;
			SetLineToDefault ();
			return;
		}

		BonusToDisplay = NewBonus;
		DisplayBonus ();
	}

	public void DisplayBonus ()
	{
		if (BonusToDisplay == null)
		{
			BonusBG.color = LockTreeColor;
			SetLineToDefault ();
			return;
		}

//		SetLineColor ();
		SetTextColor ();
		DisplayTextString ();
		ToggleIfAcquired ();
	}

	public void DisplayTextString ()
	{
		BonusText.text = BonusToDisplay.BonusName;
	}

	public void ToggleIfAcquired ()
	{
		BonusToggle.isOn = false;

		if (BonusToDisplay.State == LevelUpBonus.BonusState.Acquired) 
		{
			CheckSelectedBonus ();
		}
	}

	public void SetTextColor ()
	{
		BonusText.color = Color.black;
	}

	public void CheckSelectedBonus ()
	{
		BonusToggle.isOn = true;
		Color ToSet = Color.black;
		ToSet.a = 0.5f;
		BonusText.color = ToSet;
	}

	public void SetLineToDefault ()
	{
		BonusText.text = "";
		BonusText.color = Color.black;
		BonusToggle.isOn = false;
	}

//	public void SetLineColor ()
//	{
//		BonusBG.color = Color.clear;
//
//		if (BonusToDisplay.Tree.CurrentState == SkillTreeState.Active)
//		{
//			BonusBG.color = TypeColors.GetColorForTier (BonusToDisplay.Tree.Tier);
//		}
//
//		if (BonusToDisplay.Tree.CurrentState == SkillTreeState.Inactive)
//		{
//			Color ToSet = TypeColors.GetColorForTier (BonusToDisplay.Tree.Tier);
//			ToSet.a = 0.5f;
//			BonusBG.color = ToSet;
//		}
//	}
}
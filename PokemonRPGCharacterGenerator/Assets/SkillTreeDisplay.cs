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




	public void TreeColorUpdate ( 
		SkillTreeState state,
		string name,
		SkillTreeTier tier)
	{
		TreeBG.color = LockTreeColor;
		TreeNameText.text = name;
		if (state != SkillTreeState.Locked)
		{
			if (tier == SkillTreeTier.Tier0) 
			{
				TreeBG.color = Tier0Color;
			}

			if (tier == SkillTreeTier.Tier1) 
			{
				TreeBG.color = Tier1Color;
			}

			if (tier == SkillTreeTier.Tier2) 
			{
				TreeBG.color = Tier2Color;
			}

			if (tier == SkillTreeTier.Tier3) 
			{
				TreeBG.color = Tier3Color;
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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class SkillTreePaneDisplay : MonoBehaviour 
{
	public SkillTreeLineDisplay [] Items = new SkillTreeLineDisplay [12];
	public Image TreeBG;
	public Text TreeNameText;
	public SkillTree TreeToDisplay;

	public static Color Tier0Color = Color.gray;
	public static Color Tier1Color = Color.cyan;
	public static Color Tier2Color = Color.green;
	public static Color Tier3Color = Color.yellow;
	public static Color LockTreeColor = Color.clear;


	public void ChangeDisplayData (SkillTree NewTree)
	{
		if (NewTree == null)
		{
			TreeBG.color = LockTreeColor;
			SetDisplayToDefault ();
			return;
		}

		TreeToDisplay = NewTree;
		DisplayTree ();
	}

	public void DisplayTree ()
	{
		if (TreeToDisplay == null)
		{
			TreeBG.color = LockTreeColor;
			SetDisplayToDefault ();
			return;
		}

		TreeNameText.text = TreeToDisplay.Name;
		SetTreeColor (TreeToDisplay);

		for (int i = 0; i < Items.Length; i++)
		{
			Items [i].ChangeDisplayData (TreeToDisplay.Bonuses [i]);
		}
	}

	public void SetTreeColor (SkillTree ToDisplay)
	{
		TreeBG.color = LockTreeColor;

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

	public void SetDisplayToDefault ()
	{
		TreeNameText.text = "";
		for (int i = 0; i < Items.Length; i++)
		{
			Items [i].SetLineToDefault ();
		}
	}

}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public enum BadgeLevelStrings 
{
	SingleLevel,
	BabyLevels,
	BadgeLevel1,
	BadgeLevel2,
	BadgeLevel3,
	BadgeLevel4,
	BadgeLevel5,
	BadgeLevel6,
	BadgeLevel7,
	BadgeLevel8
}

public static class BadgeLevelExtensions 
{
	public static string GetBadgeString (this BadgeLevelStrings ThisEnum)
	{
		switch (ThisEnum) 
		{
		case BadgeLevelStrings.SingleLevel: return "Single Level";
		case BadgeLevelStrings.BabyLevels:  return "Baby Levels";
		case BadgeLevelStrings.BadgeLevel1: return "Badge Level 1";
		case BadgeLevelStrings.BadgeLevel2: return "Badge Level 2";
		case BadgeLevelStrings.BadgeLevel3: return "Badge Level 3";
		case BadgeLevelStrings.BadgeLevel4: return "Badge Level 4";
		case BadgeLevelStrings.BadgeLevel5: return "Badge Level 5";
		case BadgeLevelStrings.BadgeLevel6: return "Badge Level 6";
		case BadgeLevelStrings.BadgeLevel7: return "Badge Level 7";
		case BadgeLevelStrings.BadgeLevel8: return "Badge Level 8";
		default:
			Debug.Log ("Error");
			return "Undefined String";		
		}
	}
}

public class BadgeLevelGenerator : MonoBehaviour 
{
	public int BadgeLevel;
	public static bool AutoSelectOn;
	public BadgeLevelDisplay _BadgeLevelDisplay;
	public SkillTreesView _SkillTrees;

    public void OnBadgeLevelSelect(int value)
    {
        BadgeLevel = value;
    }

    public void OnBadgeLevelSelect ()
	{
		BadgeLevel = _BadgeLevelDisplay.BLDropDown.value;
	}

	public void OnGenerateMonClick ()
	{
		GenerateMon ((BadgeLevelStrings)BadgeLevel, GameManager.instance.CurrentPokemon);
	}

	public void GenerateMon (BadgeLevelStrings _CurrentBadgeLevelString, Pokemon _CurrentPokemon)
	{
		if (_CurrentBadgeLevelString == BadgeLevelStrings.SingleLevel) 
		{
			if(_CurrentPokemon.XP < 2)
			{
				_CurrentPokemon.XP = 2;
			}
			RollCycle ();
			_BadgeLevelDisplay.UpdateText ();
			_BadgeLevelDisplay.UpdateDisplay (_CurrentPokemon);
		}
		else 
		{
			while (_CurrentPokemon.Level < (BadgeLevel * 5 + 1))
			{
				if(_CurrentPokemon.XP < 2)
				{
					_CurrentPokemon.XP = 2;
					RollCycle ();
				} 
				else 
				{
					RollCycle ();
				}
			}
			_BadgeLevelDisplay.BadgeLevelString = _CurrentBadgeLevelString.GetBadgeString();
		}
		_BadgeLevelDisplay.UpdateText ();
		_BadgeLevelDisplay.UpdateDisplay (_CurrentPokemon);
	}



	public void RollCycle ()
	{
//		GameManager.instance._NewTreeManager.OnCallTreeRoll ();
		GameManager.instance._SkillTreeBlockController.OnAutoSelectClick ();
//		GameManager.instance.CurrentPokemon.LevelUp ();
	}
}

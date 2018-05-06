using System.Collections;
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
		case BadgeLevelStrings.BabyLevels: return "Baby Levels";
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
	public NewTreeManager _NewTreeManager;
	public MaturityManager _MaturityManager;
	public SkillTrees _SkillTrees;



public void OnBadgeLevelSelect ()
{
	BadgeLevel = _BadgeLevelDisplay.BLDropDown.value;
}

	public void OnGenerateMonClick ()
	{
		GenerateMon ((BadgeLevelStrings)BadgeLevel);
	}

	public void GenerateMon (BadgeLevelStrings CurrentBadgeLevelString)
	{
		
		if (CurrentBadgeLevelString == BadgeLevelStrings.SingleLevel) 
		{
			XPManager.XP = 1;
			RollCycle ();
			_BadgeLevelDisplay.UpdateText ();

//			_BadgeLevelDisplay.UpdateDisplay (GameManager.instance.CurrentPokemon.Level, 
//				_BadgeLevelDisplay.CurrentLevelString);
//			_BadgeLevelDisplay.CurrentLevelString = GameManager.instance.CurrentPokemon.Level.ToString ();
//			_BadgeLevelDisplay.CurrentLevelText.text = _BadgeLevelDisplay.CurrentLevelString;
		}
		else 
		{
			XPManager.XP = (BadgeLevel * 5 + 1) - GameManager.instance.CurrentPokemon.Level;
			while (GameManager.instance.CurrentPokemon.Level < (BadgeLevel * 5 + 1))
			{
				RollCycle ();
			}

			_BadgeLevelDisplay.BadgeLevelString = CurrentBadgeLevelString.GetBadgeString();
			_BadgeLevelDisplay.UpdateText ();
//			_BadgeLevelDisplay.UpdateDisplay (
//				GameManager.instance.CurrentPokemon.Level,			
//				_BadgeLevelDisplay.CurrentLevelString);
		}
		_BadgeLevelDisplay.UpdateDisplay (
			GameManager.instance.CurrentPokemon.Level,			
			_BadgeLevelDisplay.CurrentLevelString);
	}



	public void RollCycle ()
	{
		_NewTreeManager.CallTreeRoll();
		_SkillTrees.OnAutoSelectClick ();
		GameManager.instance.CurrentPokemon.LevelUp();
		GameManager.instance.CurrentPokemon.Evolve();
		GameManager.instance._MaturityManager.MaturityCheck();
	}
}
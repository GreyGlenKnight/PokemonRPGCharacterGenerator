﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BadgeLevelGenerator : MonoBehaviour 
{
public int BadgeLevel;
public Dropdown BLDropDown;
public static bool AutoSelectOn;
public int CurrentLevel = 0;
public float Rate = 3.0f;
public float CurrentMaturity;
public float TotalBaseStats = 20.0f;
public static int CurrentMaturityInt;
public int MaturityBonus = 0;
public string BadgeLevelString;
public string CurrentLevelString;
public Text BadgeLevelText;
public Text CurrentLevelText;
public bool IsShiny;
public int ShinyRNG;

	public void Evolve ()
	{
//		Debug.Log ("Evolving...");
		//Get Stats Here

		if (TotalBaseStats > 6.0f) 
		{
			Rate = 1.0f;
		}
		if (TotalBaseStats > 11.0f) 
		{
			Rate = 1.5f;
		}
		if (TotalBaseStats > 13.5f) 
		{
			Rate = 2.0f;
		}
		if (TotalBaseStats > 16.0f) 
		{
			Rate = 2.5f;
		}
		if (TotalBaseStats > 18.5f) 
		{
			Rate = 3.0f;
		}
		if (TotalBaseStats > 21.0f) 
		{
			Rate = 3.5f;
		}
		if (TotalBaseStats > 23.5f) 
		{
			Rate = 4.0f;
		}
			
//This needs an error handler if currentmaturity == 0, maybe? Only Gets called after level 1.
		CurrentMaturity = ((CurrentLevel / Rate) + MaturityBonus);
		CurrentMaturityInt = Mathf.FloorToInt (CurrentMaturity);
	}

public void SetBadgeLevel()
{
	BadgeLevel = BLDropDown.value;
}

	public void GenerateMon()
{
		if (BadgeLevel == 0)
			
		{
			XPManager.XP = 1;
			RollCycle ();
			CurrentLevelString = CurrentLevel.ToString();
			CurrentLevelText.text = CurrentLevelString;
		}

		if (BadgeLevel == 1)
		{
			XPManager.XP = 6 - CurrentLevel;
			while (CurrentLevel < 6)
			{
				RollCycle ();
			}
			BadgeLevelString = "Baby Levels";
			UpdateText ();
		}

		if (BadgeLevel == 2)
		{
			XPManager.XP = 11 - CurrentLevel;
			while (CurrentLevel < 11)
			{
				RollCycle ();
			}
			BadgeLevelString = "Badge Level 1";
			UpdateText ();
		}

		if (BadgeLevel == 3)
		{
			XPManager.XP = 16 - CurrentLevel;
			while (CurrentLevel < 16)
			{
				RollCycle ();
			}
			BadgeLevelString = "Badge Level 2";
			UpdateText ();
		}

		if (BadgeLevel == 4)
		{
			XPManager.XP = 21 - CurrentLevel;
			while (CurrentLevel < 21)
			{
				RollCycle ();
			}
			BadgeLevelString = "Badge Level 3";
			UpdateText ();
		}

		if (BadgeLevel == 5)
		{
			XPManager.XP = 26 - CurrentLevel;
			while (CurrentLevel < 26)
			{
				RollCycle ();
			}
			BadgeLevelString = "Badge Level 4";
			UpdateText ();
		}

		if (BadgeLevel == 6)
		{
			XPManager.XP = 31 - CurrentLevel;
			while (CurrentLevel < 31)
			{
				RollCycle ();
			}
			BadgeLevelString = "Badge Level 5";
			UpdateText ();
		}

		if (BadgeLevel == 7)
		{
			XPManager.XP = 36 - CurrentLevel;
			while (CurrentLevel < 36)
			{
				RollCycle ();
			}
			BadgeLevelString = "Badge Level 6";
			UpdateText ();
		}

		if (BadgeLevel == 8)
		{
			XPManager.XP = 41 - CurrentLevel;
			while (CurrentLevel < 41)
			{
				RollCycle ();
			}
			BadgeLevelString = "Badge Level 7";
			UpdateText ();
		}

		if (BadgeLevel == 9)
		{
			XPManager.XP = 46 - CurrentLevel;
			while (CurrentLevel < 46)
			{
				RollCycle ();
			}
			BadgeLevelString = "Badge Level 8";
			UpdateText ();
		}
}

	public void UpdateText ()
	{
		BadgeLevelText.text = BadgeLevelString;
		CurrentLevelString = CurrentLevel.ToString ();
		CurrentLevelText.text = CurrentLevelString;
	}

	public void RollCycle ()
	{
		gameObject.GetComponent<NewTreeManager>().CallTreeRoll();
		gameObject.GetComponent<AutoSelectManager>().AutoSelect();
		CurrentLevel++;
		Evolve();
		gameObject.GetComponent<MaturityManager>().MaturityCheck();
	}

	public void Start ()
	{
		ShinyRNG = Random.Range (0, 4096);
		Debug.Log (ShinyRNG);

		if (ShinyRNG == 0) 
		{
			IsShiny = true;
			Debug.Log ("Holy Shit, a Shiny!");
		}
	}
}
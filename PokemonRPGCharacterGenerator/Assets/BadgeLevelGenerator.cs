using System.Collections;
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
public string BadgeLevelString;
public string CurrentLevelString;
public Text BadgeLevelText;
public Text CurrentLevelText;


public void SetBadgeLevel()
{
	BadgeLevel = BLDropDown.value;
}

	public void GenerateMon()
{
//		if (gameObject.GetComponent<GameManager>(AutoSelectOn) == false)
////		{return;}
		if (BadgeLevel == 0)
			
		{
			GameManager.XP = 1;
				gameObject.GetComponent<GameManager>().CallTreeRoll();
				gameObject.GetComponent<AutoSelectManager>().AutoSelect();
				CurrentLevel++;
			CurrentLevelString = CurrentLevel.ToString();
			CurrentLevelText.text = CurrentLevelString;

			}
			

		if (BadgeLevel == 1)
		{
			GameManager.XP = 6 - CurrentLevel;
			while (CurrentLevel < 6)
			{
				gameObject.GetComponent<GameManager>().CallTreeRoll();
				gameObject.GetComponent<AutoSelectManager>().AutoSelect();
				CurrentLevel++;
			}
			BadgeLevelString = "Baby Levels";
			BadgeLevelText.text = BadgeLevelString;
			CurrentLevelString = CurrentLevel.ToString();
			CurrentLevelText.text = CurrentLevelString;
		}

		if (BadgeLevel == 2)
		{
			GameManager.XP = 11 - CurrentLevel;
			while (CurrentLevel < 11)
			{
				gameObject.GetComponent<GameManager>().CallTreeRoll();
				gameObject.GetComponent<AutoSelectManager>().AutoSelect();
				CurrentLevel++;
			}
			BadgeLevelString = "Badge Level 1";
			BadgeLevelText.text = BadgeLevelString;
			CurrentLevelString = CurrentLevel.ToString();
			CurrentLevelText.text = CurrentLevelString;
		}

		if (BadgeLevel == 3)
		{
			GameManager.XP = 16 - CurrentLevel;
			while (CurrentLevel < 16)
			{
				gameObject.GetComponent<GameManager>().CallTreeRoll();
				gameObject.GetComponent<AutoSelectManager>().AutoSelect();
				CurrentLevel++;
			}
			BadgeLevelString = "Badge Level 2";
			BadgeLevelText.text = BadgeLevelString;
			CurrentLevelString = CurrentLevel.ToString();
			CurrentLevelText.text = CurrentLevelString;
		}

		if (BadgeLevel == 4)
		{
			GameManager.XP = 21 - CurrentLevel;
			while (CurrentLevel < 21)
			{
				gameObject.GetComponent<GameManager>().CallTreeRoll();
				gameObject.GetComponent<AutoSelectManager>().AutoSelect();
				CurrentLevel++;
			}
			BadgeLevelString = "Badge Level 3";
			BadgeLevelText.text = BadgeLevelString;
			CurrentLevelString = CurrentLevel.ToString();
			CurrentLevelText.text = CurrentLevelString;
		}

		if (BadgeLevel == 5)
		{
			GameManager.XP = 26 - CurrentLevel;
			while (CurrentLevel < 26)
			{
				gameObject.GetComponent<GameManager>().CallTreeRoll();
				gameObject.GetComponent<AutoSelectManager>().AutoSelect();
				CurrentLevel++;
			}
			BadgeLevelString = "Badge Level 4";
			BadgeLevelText.text = BadgeLevelString;
			CurrentLevelString = CurrentLevel.ToString();
			CurrentLevelText.text = CurrentLevelString;
		}

		if (BadgeLevel == 6)
		{
			GameManager.XP = 31 - CurrentLevel;
			while (CurrentLevel < 31)
			{
				gameObject.GetComponent<GameManager>().CallTreeRoll();
				gameObject.GetComponent<AutoSelectManager>().AutoSelect();
				CurrentLevel++;
			}
			BadgeLevelString = "Badge Level 5";
			BadgeLevelText.text = BadgeLevelString;
			CurrentLevelString = CurrentLevel.ToString();
			CurrentLevelText.text = CurrentLevelString;
		}

		if (BadgeLevel == 7)
		{
			GameManager.XP = 36 - CurrentLevel;
			while (CurrentLevel < 36)
			{
				gameObject.GetComponent<GameManager>().CallTreeRoll();
				gameObject.GetComponent<AutoSelectManager>().AutoSelect();
				CurrentLevel++;
			}
			BadgeLevelString = "Badge Level 6";
			BadgeLevelText.text = BadgeLevelString;
			CurrentLevelString = CurrentLevel.ToString();
			CurrentLevelText.text = CurrentLevelString;
		}

		if (BadgeLevel == 8)
		{
			GameManager.XP = 41 - CurrentLevel;
			while (CurrentLevel < 41)
			{
				gameObject.GetComponent<GameManager>().CallTreeRoll();
				gameObject.GetComponent<AutoSelectManager>().AutoSelect();
				CurrentLevel++;
			}
			BadgeLevelString = "Badge Level 7";
			BadgeLevelText.text = BadgeLevelString;
			CurrentLevelString = CurrentLevel.ToString();
			CurrentLevelText.text = CurrentLevelString;
		}

		if (BadgeLevel == 9)
		{
			GameManager.XP = 46 - CurrentLevel;
			while (CurrentLevel < 46)
			{
				gameObject.GetComponent<GameManager>().CallTreeRoll();
				gameObject.GetComponent<AutoSelectManager>().AutoSelect();
				CurrentLevel++;
			}
			BadgeLevelString = "Badge Level 8";
			BadgeLevelText.text = BadgeLevelString;
			CurrentLevelString = CurrentLevel.ToString();
			CurrentLevelText.text = CurrentLevelString;
		}

}

}
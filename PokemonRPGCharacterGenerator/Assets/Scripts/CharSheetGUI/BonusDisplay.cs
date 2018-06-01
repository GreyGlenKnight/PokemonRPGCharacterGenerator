using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class BonusDisplay : MonoBehaviour
{
	public Text Name; //Primarily the type of bonus
//	public Text MaturityLevelGained;
//	public Text NumberOfSameTypeBonuses; //For example, STAB #4 or Ability #3
	public Text Description;
	public Text LevelGained;
	public List <Sprite> StatsToUse = new List <Sprite> ();
	public List <Sprite> TypesToUse = new List <Sprite> ();


	public BonusDisplay ()
	{

	}

//	public BonusDisplay (IHistoryItem _Item)
//	{
//		Name.text = _Item.Name;
//		Description.text = _Item.Description;
//		LevelGained.text = "Gained At Level: "+_Item.LevelGained.ToString()+" Maturity: "+_Item.MaturityLevel.ToString();
//	}

	public void ChangeDisplay (IHistoryItem _Item)
	{
		Name.text = _Item.Name;
		Description.text = _Item.Description+" "+" Maturity: "+_Item.MaturityLevel.ToString();
		LevelGained.text = "Gained At Level: "+_Item.LevelGained.ToString();
		//Stats and type return sprites;
	}

}

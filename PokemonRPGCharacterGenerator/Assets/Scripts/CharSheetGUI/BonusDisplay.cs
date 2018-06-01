using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

	public class BonusDisplay
{
	public Text Name; //Primarily the type of bonus
	public Text MaturityLevelGained;
	public Text NumberOfSameTypeBonuses; //For example, STAB #4 or Ability #3
	public Text Description;
	public Text XPLevelGained;
	public List <Sprite> StatsToUse = new List <Sprite> ();
	public List <Sprite> TypesToUse = new List <Sprite> ();



	public BonusDisplay (MaturityBonus _Bonus)
	{
		
	}

	public BonusDisplay (LevelUpBonus _Bonus)
	{
		
	}

	public BonusDisplay (LevelUpBonus _Bonus, Technique _TechToUse)
	{

	}

}

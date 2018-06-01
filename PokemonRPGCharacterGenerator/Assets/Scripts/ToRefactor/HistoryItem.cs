using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public enum BonusType
{
	None,
	Birth,
	LevelUp,
	MaturityBonus,
	UsedEnhancer,
	SpecialTraining,
	Evolution,
	//MajorVictory,
	//GainSupportBonus?
	//BadEvent,
	//Trade,
	//Breeding,
}

public interface IHistoryItem
{
	int LevelGained { get;}
	int MaturityLevel { get;}
	string Name { get;}
	string Description { get;}
	BonusType Type { get;}
	Sprite GetRepresentedSprite { get;}
}


//Have a unique sprite for bonus type, such as a badge symbol for
//winning a gym battle.

//Double battle victories should store the pokemon it fought with
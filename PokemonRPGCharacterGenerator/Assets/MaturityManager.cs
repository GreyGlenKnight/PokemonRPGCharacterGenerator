using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class MaturityManager : MonoBehaviour 
{

	public List <MaturityRank> MaturityBonusList = new List <MaturityRank> ();
	public int CurrentMaturity;
	public string [] Maturity = new string []
	{
		"Gain and Break Baby Skill, Birth Ability",
		"Break Adult Tree, Nature",
		"Bonus Level 1",
		"Gain Adult Tree, Gain Ability Slot 2",
		"Break Skill 1, STAB Bonus +1",
		"Bonus Level 2",
		"Gain Skill 1, Special Training Slot 1",
		"Break Skill 1, Enhancer Slot 1",
		"Bonus Level 3",
		"Trade Skill 1, Attribute Bonus 2",
		"Break Skill 2, STAB Bonus 2",
		"Bonus Level 4",
		"Special Training Slot 2",
		"Break Skill 1, Ability Slot 3",
		"Bonus Level 5",
		"Break Skill 1, Enhancer Slot 2",
		"Trade Skill 1, STAB Bonus 3",
		"Bonus Level 6",
		"Gain Skill 1, Break Skill 3",
		"Break Skill 2",
		"Bonus Level 7",
		"Trade Skill 2, Break Skill 3",
		"STAB Bonus 4",
		"Bonus Level 8",
		"Trade Skill 2, Attribute Bonus 3",
		"Special Training Slot 3",
		"Bonus Level 9",
		"Break Skill 3",
		"STAB Bonus 5",
		"Bonus Level 10",
		"Trade Skill 3",
		"Enhancer Slot 3",
		"Bonus Level 11",
		"Break Skill 3",
		"STAB Bonus 6",
		"Bonus Level 12",
		"Trade Skill 3",
		"Attribute Bonus 4",
		"Bonus Level 13",
		"Enhancer Bonus 4",
		"STAB Bonus 7"};
	public List <int> HighestMaturity = new List <int> ();
	public int HMItem1;

	void Awake ()
	{
		for (int i = 0; i < 41; i++) 
		{
			MaturityBonusList.Add (new MaturityRank (i, Maturity [i]));
		}
	}

	public void EliminateMaturityBonus ()
	{
		CurrentMaturity++;
	}


	public void MaturityCheck ()
	{
		CurrentMaturity = BadgeLevelGenerator.CurrentMaturityInt;
		HMItem1 = MaturityBonusList [0].Maturity;

		if (CurrentMaturity > 40) 
		{return;}

		if (HMItem1 < CurrentMaturity)
		{
			EliminateMaturityBonus ();
		}
	}

}
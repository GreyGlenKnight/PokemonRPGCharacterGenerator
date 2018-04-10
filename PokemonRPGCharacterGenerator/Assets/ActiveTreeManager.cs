using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class ActiveTreeManager : MonoBehaviour 
{

	public List <string> MaturityBonusList = new List <string> ();
	public int Maturity;
	public List <int> HighestMaturity = new List <int> ();
	public int HMItem1;
	public List <TreeManager> ActiveTreesList = new List <TreeManager> ();
	string Maturity0 = "Gain and Break Baby Skill, Birth Ability";
	string Maturity1 ="Break Adult Tree, Nature";
	string Maturity2 ="Bonus Level 1";
	string Maturity3 ="Gain Adult Tree, Gain Ability Slot 2";
	string Maturity4 ="Break Skill 1, STAB Bonus +1";
	string Maturity5 ="Bonus Level 2";
	string Maturity6 ="Gain Skill 1, Special Training Slot 1";
	string Maturity7 ="Break Skill 1, Enhancer Slot 1";
	string Maturity8 ="Bonus Level 3";
	string Maturity9 ="Trade Skill 1, Attribute Bonus 2";
	string Maturity10 ="Break Skill 2, STAB Bonus 2";
	string Maturity11 ="Bonus Level 4";
	string Maturity12 ="Special Training Slot 2";
	string Maturity13 ="Break Skill 1, Ability Slot 3";
	string Maturity14 ="Bonus Level 5";
	string Maturity15 ="Break Skill 1, Enhancer Slot 2";
	string Maturity16 ="Trade Skill 1, STAB Bonus 3";
	string Maturity17 ="Bonus Level 6";
	string Maturity18 ="Gain Skill 1, Break Skill 3";
	string Maturity19 ="Break Skill 2";
	string Maturity20 ="Bonus Level 7";
	string Maturity21 ="Trade Skill 2, Break Skill 3";
	string Maturity22 ="STAB Bonus 4";
	string Maturity23 ="Bonus Level 8";
	string Maturity24 ="Trade Skill 2, Attribute Bonus 3";
	string Maturity25 ="Special Training Slot 3";
	string Maturity26 ="Bonus Level 9";
	string Maturity27 ="Break Skill 3";
	string Maturity28 = "STAB Bonus 5";
	string Maturity29 ="Bonus Level 10";
	string Maturity30 ="Trade Skill 3";
	string Maturity31 ="Enhancer Slot 3";
	string Maturity32 ="Bonus Level 11";
	string Maturity33 ="Break Skill 3";
	string Maturity34 ="STAB Bonus 6";
	string Maturity35 ="Bonus Level 12";
	string Maturity36 ="Trade Skill 3";
	string Maturity37 ="Attribute Bonus 4";
	string Maturity38 ="Bonus Level 13";
	string Maturity39 ="Enhancer Bonus 4";
	string Maturity40 ="STAB Bonus 7";




	void Awake ()
	{
		for (int i = 0; i < 41; i++) 
		{
			HighestMaturity.Add (i);
		}

		MaturityBonusList.Add (Maturity0);
		MaturityBonusList.Add (Maturity1);
		MaturityBonusList.Add (Maturity2);
		MaturityBonusList.Add (Maturity3);
		MaturityBonusList.Add (Maturity4);
		MaturityBonusList.Add (Maturity5);
		MaturityBonusList.Add (Maturity6);
		MaturityBonusList.Add (Maturity7);
		MaturityBonusList.Add (Maturity8);
		MaturityBonusList.Add (Maturity9);
		MaturityBonusList.Add (Maturity10);
		MaturityBonusList.Add (Maturity11);
		MaturityBonusList.Add (Maturity12);
		MaturityBonusList.Add (Maturity13);
		MaturityBonusList.Add (Maturity14);
		MaturityBonusList.Add (Maturity15);
		MaturityBonusList.Add (Maturity16);
		MaturityBonusList.Add (Maturity17);
		MaturityBonusList.Add (Maturity18);
		MaturityBonusList.Add (Maturity19);
		MaturityBonusList.Add (Maturity20);
		MaturityBonusList.Add (Maturity21);
		MaturityBonusList.Add (Maturity22);
		MaturityBonusList.Add (Maturity23);
		MaturityBonusList.Add (Maturity24);
		MaturityBonusList.Add (Maturity25);
		MaturityBonusList.Add (Maturity26);
		MaturityBonusList.Add (Maturity27);
		MaturityBonusList.Add (Maturity28);
		MaturityBonusList.Add (Maturity29);
		MaturityBonusList.Add (Maturity30);
		MaturityBonusList.Add (Maturity31);
		MaturityBonusList.Add (Maturity32);
		MaturityBonusList.Add (Maturity33);
		MaturityBonusList.Add (Maturity34);
		MaturityBonusList.Add (Maturity35);
		MaturityBonusList.Add (Maturity36);
		MaturityBonusList.Add (Maturity37);
		MaturityBonusList.Add (Maturity38);
		MaturityBonusList.Add (Maturity39);
		MaturityBonusList.Add (Maturity40);

	}

	public void EliminateMaturityBonus ()
	{
	HighestMaturity.RemoveAt (0);
	MaturityBonusList.RemoveAt (0);
	}


	public void MaturityCheck ()
	{
		Maturity = BadgeLevelGenerator.CurrentMaturityInt;
		HMItem1 = HighestMaturity [0];

		if (Maturity > 40) 
		{return;}

		if (HMItem1 < Maturity)
		{
			EliminateMaturityBonus ();
		}
//				Debug.Log (MaturityBonusList.Count);
		Debug.Log (MaturityBonusList [0]);
				Debug.Log (Maturity);
	}
	



}
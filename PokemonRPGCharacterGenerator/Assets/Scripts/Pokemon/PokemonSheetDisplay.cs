using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class PokemonSheetDisplay : MonoBehaviour 
{
	public Text BreedName; // breedname will not be stored in breed, rather its title
	public Text PokemonName; //nickname
	public InputField NickNameInput;
	public InputField TrainerInput;
	public Text TrainerName; 
	public Text ElementType1;
	public Text ElementType2;
	public Image Background1;	
	public Image Background2;
//	public GameObject PanelType1;
//	public GameObject PanelType2;

	public Text Ability1Title;
	public Text Ability2Title;
	public Text Ability3Title;
	public Text Ability1Description;
	public Text Ability2Description;
	public Text Ability3Description;
	public Text MaxHP;
	public Text CurrentHP;
	public Text MaxStrain;
	public Text CurrentStrain;
	public Text Fatigue;

	public Text BaseEndurance;
	public Text CurrentEndurance;
	public Text BaseAttack;
	public Text CurrentAttack;
	public Text BaseDefense;
	public Text CurrentDefense;
	public Text BaseSpecialAttack;
	public Text CurrentSpecialAttack;
	public Text BaseSpecialDefense;
	public Text CurrentSpecialDefense;
	public Text BaseSpeed;
	public Text CurrentSpeed;

	public List <ElementTypes> ElementSkillsList = new List <ElementTypes> ();

	//Skills as an array of a type, sort and display 4, rest on hover panel

	//Pokemon Moves as an array of a type
	//5 Active Moves?
	//Should know the bonuses from pokemon

	public Text XP;
	public Text Level;
	public Text _HeldItem;
//	public Text BaseMaturity; //This will be incremented by leveling
	public Text CurrentMaturity; //This will be incremented by leveling and bonuses
//	public Text MaturityBonus; //This will only be incremented by bonus
	public Image Portrait;
	public Text Rate;
//	public Text RateRemainder;



	public void SetStatBlock (Pokemon ToSet, Pokemon.Breed BreedToSet)
	{
		//could probably make add'tl functions to build this
		string EnduranceBonuses = ToSet.NumberOfEnduranceBonuses.RawValue.ToString ();
		BaseEndurance.text = BreedToSet.BaseEndurance.RawValue.ToString () + "   + " + EnduranceBonuses + " ";
		CurrentEndurance.text = ToSet.Endurance.RawValue.ToString ();


		string AttackBonuses = (ToSet.NumberOfAttackBonuses.RoundedValue).ToString ();
		if (ToSet.NumberOfAttackBonuses.RawValue % 2 == 1) 
		{
			string TempString = AttackBonuses+".5";
			AttackBonuses = TempString;
		}
		if (BreedToSet.BaseAttack.RawValue % 2 == 0) 
		{
			BaseAttack.text = BreedToSet.BaseAttack.RoundedValue.ToString () + "   + " + AttackBonuses + " ";
		}
		else
		{
			BaseAttack.text = BreedToSet.BaseAttack.RoundedValue.ToString () + ".5 + " + AttackBonuses + " ";
		}
		CurrentAttack.text = ToSet.Attack.RoundedValue.ToString ();


		string DefenseBonuses = (ToSet.NumberOfDefenseBonuses.RoundedValue).ToString ();
		if (ToSet.NumberOfDefenseBonuses.RawValue % 2 == 1) 
		{
			string TempString = DefenseBonuses+".5";
			DefenseBonuses = TempString;
		}
		if (BreedToSet.BaseDefense.RawValue % 2 == 0) 
		{
			BaseDefense.text = BreedToSet.BaseDefense.RoundedValue.ToString () + "   + " + DefenseBonuses + " "; 
		} 
		else 
		{
			BaseDefense.text = BreedToSet.BaseDefense.RoundedValue.ToString () + ".5 + " + DefenseBonuses + " "; 
		}
		CurrentDefense.text = ToSet.Defense.RoundedValue.ToString ();


		string SpecialAttackBonuses = (ToSet.NumberOfSpecialAttackBonuses.RoundedValue).ToString ();
		if (ToSet.NumberOfSpecialDefenseBonuses.RawValue % 2 == 1) 
		{
			string TempString = SpecialAttackBonuses+".5";
			SpecialAttackBonuses = TempString;
		}
		if (BreedToSet.BaseSpecialAttack.RawValue % 2 == 0) 
		{
			BaseSpecialAttack.text = BreedToSet.BaseSpecialAttack.RoundedValue.ToString () + "   + " + SpecialAttackBonuses + " ";
		} 
		else 
		{
			BaseSpecialAttack.text = BreedToSet.BaseSpecialAttack.RoundedValue.ToString () + ".5 + " + SpecialAttackBonuses + " ";
		}
		CurrentSpecialAttack.text = ToSet.SpecialAttack.RoundedValue.ToString ();


		string SpecialDefenseBonuses = (ToSet.NumberOfSpecialDefenseBonuses.RoundedValue).ToString ();
		if (ToSet.NumberOfSpecialDefenseBonuses.RawValue % 2 == 1) 
		{
			string TempString = SpecialDefenseBonuses+".5";
			SpecialDefenseBonuses = TempString;
		}
		if (BreedToSet.BaseSpecialDefense.RawValue % 2 == 0) 
		{
			BaseSpecialDefense.text = BreedToSet.BaseSpecialDefense.RoundedValue.ToString () + "   + " + SpecialDefenseBonuses + " ";
		}
		else 
		{
			BaseSpecialDefense.text = BreedToSet.BaseSpecialDefense.RoundedValue.ToString () + ".5 + " + SpecialDefenseBonuses + " ";
		}
		CurrentSpecialDefense.text = ToSet.SpecialDefense.RoundedValue.ToString ();


		string SpeedBonuses = (ToSet.NumberOfSpeedBonuses.RoundedValue).ToString ();
		if (ToSet.NumberOfSpeedBonuses.RawValue % 2 == 1) 
		{
			string TempString = SpeedBonuses+".5";
			SpeedBonuses = TempString;
		}
		if (BreedToSet.BaseSpeed.RawValue % 2 == 0) 
		{
			BaseSpeed.text = BreedToSet.BaseSpeed.RoundedValue.ToString () + "   + " + SpeedBonuses + " ";
		} 
		else 
		{
			BaseSpeed.text = BreedToSet.BaseSpeed.RoundedValue.ToString () + ".5 + " + SpeedBonuses + " ";
		}
		CurrentSpeed.text = ToSet.Speed.RoundedValue.ToString ();

	}

	public void SetSkillRanks ()
	{
	}

	public void SetMoves ()
	{
	}

	public void SetAbilities (Pokemon ToSet)
	{
		Ability1Title.text = "Dragon Soul";
		Ability2Title.text = "Melee Fighter";
		Ability3Title.text = "Mischievous";
		Ability1Description.text = "Evade(2): Gain Dragon typing (Can have Dragon type x2) until next turn";
		Ability2Description.text = "Melee Fighter,+1 accuracy for melee attacks";
		Ability3Description.text = "Status attacks have +1 accuracy";
		//Pokemon.ActiveAbilities.descriptions/titles
	}

	public void SetNickNameField ()
	{
		string InputName = NickNameInput.text.ToString ();
		GameManager.instance.CurrentPokemon.NickName = InputName;
		Debug.Log (GameManager.instance.CurrentPokemon.NickName);
	}

	public void SetTrainerNameField ()
	{
		string InputName = TrainerInput.text.ToString ();
		GameManager.instance.CurrentPokemon.TrainerName = InputName;
		Debug.Log (GameManager.instance.CurrentPokemon.TrainerName);

	}

	public void SetTypes (Pokemon ToSet, Pokemon.Breed BreedToSet)
	{
		ElementType1.text = BreedToSet.Type1.ToString();

		int Type1Index = (int) BreedToSet.Type1;
		int Type2Index = (int) BreedToSet.Type2;

		Background1.color = TypeColors.TypeColorList.ElementAt (Type1Index);
		ElementType1.color = TypeColors.TypeColorList.ElementAt (Type1Index);
		if (Type2Index == 0) 
		{
			Background2.color = TypeColors.TypeColorList.ElementAt (Type1Index);
			ElementType2.color = TypeColors.TypeColorList.ElementAt (Type2Index);
			ElementType2.text = "";
			ElementType1.alignment = TextAnchor.MiddleCenter;
//			Debug.Log (ElementType2.alignment.ToString());
		} 
		else 
		{
			ElementType1.alignment = TextAnchor.MiddleLeft;
			Background2.color = TypeColors.TypeColorList.ElementAt (Type2Index);
			ElementType2.color = TypeColors.TypeColorList.ElementAt (Type2Index);
		}
		//Debug.Log (Type1Index+ElementType1.ToString()+BreedToSet.ToString());
		//BGPanels and typecolors
		//This to replace the buttons
	}

	public void SetItem (Pokemon ToSet)
	{
		_HeldItem.text = ToSet.HeldItem;
		//May want an item sprite
	}

	public void SetXP (Pokemon ToSet)
	{
		string BaseMaturity = ((ToSet.Level * 2) / ToSet.Rate).ToString();
		string MaturityBonus = (((ToSet.Level * 2) / ToSet.Rate) - ToSet.Maturity).ToString();
		string _CurrentMaturity = ToSet.Maturity.ToString();
		XP.text = ToSet.XP.ToString();
		Level.text = ToSet.Level.ToString();
		CurrentMaturity.text = BaseMaturity+" "+"+"+MaturityBonus+" "+"("+_CurrentMaturity+")";
	}

	public void SetVitals (Pokemon ToSet)
	{
		MaxHP.text = "/"+ToSet.MaxHP.ToString();
		CurrentHP.text = (ToSet.MaxHP - ToSet.CurrentDamage).ToString();
		MaxStrain.text = "/"+ToSet.MaxStrain.ToString();
		CurrentStrain.text = (ToSet.MaxStrain - ToSet.CurrentStrainLost).ToString();
		Fatigue.text = "TODO";
	}

	public void SetPortrait (Pokemon ToSet)
	{
		Debug.Log ("Set Portrait");
		if (ToSet.IsShiny == true) 
		{
			Debug.Log ("Shiny Portrait");
		}
	}

	public void SetNames (Pokemon ToSet, Pokemon.Breed BreedToSet)
	{
		BreedName.text = BreedToSet.BreedName;
		PokemonName.text = ToSet.NickName;
		TrainerName.text = ToSet.TrainerName;
	}

	public void SetRate (Pokemon ToSet)
	{
		int TempRate = (ToSet.Rate / 2);
		string TempString = TempRate.ToString ();
		Rate.text = TempRate.ToString();
		if (ToSet.Rate % 2 == 1)
		{Rate.text = (TempString+".5");}
		else 
		{Rate.text = (TempString+".0");}
	}


	public void ShowNewPokemon (Pokemon ToSet, Pokemon.Breed BreedToSet)
	{
		//May perform same function as awake, but takes input Pokemon so we 
		//Want that to be created first.
		SetRate (ToSet);
		SetNames (ToSet, BreedToSet);
		SetPortrait (ToSet);
		SetVitals (ToSet);
		SetXP (ToSet);
		SetItem (ToSet);
		SetAbilities (ToSet);
		SetStatBlock (ToSet, BreedToSet);
		SetTypes (ToSet, BreedToSet);
		SetMoves ();
		SetSkillRanks ();
	}

	public void Awake ()
	{
		//We want to set a bunch of functions, using current pokemon as input parameter
		//Probably ShowNewPokemon will have all the necessary subroutines
	}


}

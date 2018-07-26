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
//	public Text ElementType1;
//	public Text ElementType2;
	public Image Background1;	
	public Image Background2;
//	public Sprite ElementTypeSymbol1;
//	public Sprite ElementTypeSymbol2;
	public Image ElementTypeSymbol1;
	public Image ElementTypeSymbol2;

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

	public List <TechniqueDisplay> TechsList = new List <TechniqueDisplay> ();
	public bool IsTechsListShowing = true;

	public List <ElementTypes> ElementSkillsList = new List <ElementTypes> ();

	public Text XP;
	public Text Level;
	public Text _HeldItem;
	public Text CurrentMaturity;
	public Image Portrait;
	public Text Rate;



	public void SetStatBlock (Pokemon ToSet, Pokemon.Breed BreedToSet)
	{
		string EnduranceBonuses = ToSet.NumberOfEnduranceBonuses.RawValue.ToString ();
		BaseEndurance.text = BreedToSet.BaseEndurance.RawValue.ToString () + "   + " + EnduranceBonuses + " ";
		CurrentEndurance.text = ToSet.Endurance.RawValue.ToString ();

		BaseAttack.text = SetStatString (ToSet.NumberOfAttackBonuses, 
			BreedToSet.BaseAttack);
		CurrentAttack.text = ToSet.Attack.RoundedValue.ToString ();

		BaseDefense.text = SetStatString (ToSet.NumberOfDefenseBonuses, 
			BreedToSet.BaseDefense);
		CurrentDefense.text = ToSet.Defense.RoundedValue.ToString ();

		BaseSpecialAttack.text = SetStatString (ToSet.NumberOfSpecialAttackBonuses, 
			BreedToSet.BaseSpecialAttack);
		CurrentSpecialAttack.text = ToSet.SpecialAttack.RoundedValue.ToString ();

		BaseSpecialDefense.text = SetStatString (ToSet.NumberOfSpecialDefenseBonuses, 
			BreedToSet.BaseSpecialDefense);
		CurrentSpecialDefense.text = ToSet.SpecialDefense.RoundedValue.ToString ();

		BaseSpeed.text = SetStatString (ToSet.NumberOfSpeedBonuses, 
			BreedToSet.BaseSpeed);
		CurrentSpeed.text = ToSet.Speed.RoundedValue.ToString ();
	}

	public string SetStatString (MyStat _Stat, MyStat _Stat2)
	{
		string _StatBonuses = (_Stat.RoundedValue).ToString ();
		if (_Stat.RawValue % 2 == 1) 
		{
			string TempString = _StatBonuses+".5";
			_StatBonuses = TempString;
		}
		if (_Stat2.RawValue % 2 == 0) 
		{
			return _Stat2.RoundedValue.ToString () + "   + " + _StatBonuses + " ";
		}
		else
		{
			return _Stat2.RoundedValue.ToString () + ".5 + " + _StatBonuses + " ";
		}
		//	This function replaces this:
		//		string AttackBonuses = (ToSet.NumberOfAttackBonuses.RoundedValue).ToString ();
		//		if (ToSet.NumberOfAttackBonuses.RawValue % 2 == 1) 
		//		{
		//			string TempString = AttackBonuses+".5";
		//			AttackBonuses = TempString;
		//		}
		//		if (BreedToSet.BaseAttack.RawValue % 2 == 0) 
		//		{
		//			BaseAttack.text = BreedToSet.BaseAttack.RoundedValue.ToString () + "   + " + AttackBonuses + " ";
		//		}
		//		else
		//		{
		//			BaseAttack.text = BreedToSet.BaseAttack.RoundedValue.ToString () + ".5 + " + AttackBonuses + " ";
		//		}
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

	public void SetTypes (Pokemon.Breed BreedToSet)
	{
		Background1.color = TypeColors.GetColorForType (BreedToSet.Type1);
	
		if ((int)BreedToSet.Type2 == 0) 
		{
			Background2.color = TypeColors.GetColorForType (BreedToSet.Type1);
			ElementTypeSymbol2.gameObject.SetActive (false);
		} 
		else 
		{
			Background2.color = TypeColors.GetColorForType (BreedToSet.Type2);
			ElementTypeSymbol2.sprite = TypeColors.GetSpriteForType (BreedToSet.Type2);
		}
		ElementTypeSymbol1.sprite = TypeColors.GetSpriteForType (BreedToSet.Type1);
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
		MaxHP.text = "/"+ToSet.MaxHP.ToString()+" ";
		CurrentHP.text = (ToSet.MaxHP - ToSet.CurrentDamage).ToString();
		MaxStrain.text = "/"+ToSet.MaxStrain.ToString()+" ";
		CurrentStrain.text = (ToSet.MaxStrain - ToSet.CurrentStrainLost).ToString();
		Fatigue.text = " --   ";
	}

	public void SetPortrait (Pokemon ToSet)
	{
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
//		Rate.text = TempRate.ToString();
		if (ToSet.Rate % 2 == 1)
		{Rate.text = (TempString+".5");}
		else 
		{Rate.text = (TempString+".0");}
	}

	public void OnLevelUp (object o, LevelUpEventArgs e)
	{
		e._Pokemon.OnChooseLevelUpBonus -= OnLevelUp;
		ShowNewPokemon (e._Pokemon, 
			e._Pokemon.ThisBreed);
	}

	public void ShowNewPokemon (Pokemon ToSet, Pokemon.Breed BreedToSet)
	{
		SetRate (ToSet);
		SetNames (ToSet, BreedToSet);
		SetPortrait (ToSet);
		SetVitals (ToSet);
		SetXP (ToSet);
		SetItem (ToSet);
		SetAbilities (ToSet);
		SetStatBlock (ToSet, BreedToSet);
		SetTypes (BreedToSet);
		SetMoves ();
		SetSkillRanks ();
		ToSet.OnChooseLevelUpBonus += OnLevelUp;
	}

	public void HideTechsView ()
	{
		switch (IsTechsListShowing)
		{	
		case true:
			for (int i = 0; i < TechsList.Count; i++) 
			{
				TechsList [i].gameObject.SetActive (false);
			}
			IsTechsListShowing = false;
			return;

		case false:
			for (int i = 0; i < TechsList.Count; i++) 
			{
				TechsList [i].gameObject.SetActive (true);
			}
			IsTechsListShowing = true;
			return;

		default:
			Debug.Log ("HideTechsView has a new case?");
			return;
		}
	}
}

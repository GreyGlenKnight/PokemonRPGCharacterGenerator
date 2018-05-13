using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public enum ElementTypes
{
	Nothing,
	Normal,
	Fire,
	Water,
	Electric,
	Grass,
	Ice,
	Fighting,
	Poison,
	Ground,
	Flying,
	Psychic,
	Bug,
	Rock,
	Ghost,
	Dragon,
	Dark,
	Steel,
	Fairy
}

public class Pokemon

{
	public int Level = 0;
	public int Maturity; //This represents the relevant total maturity
	public int Rate; //Rate int is essentially doubled
	public int XP;
	public int CurrentDamage;
	public int CurrentStrainLost;
	private Breed _Breed;
	public EnduranceStat NumberOfEnduranceBonuses = new EnduranceStat (0);
	public AttackStat NumberOfAttackBonuses = new AttackStat (0);
	public DefenseStat NumberOfDefenseBonuses = new DefenseStat (0);
	public SpecialAttackStat NumberOfSpecialAttackBonuses = new SpecialAttackStat (0);
	public SpecialDefenseStat NumberOfSpecialDefenseBonuses = new SpecialDefenseStat (0);
	public SpeedStat NumberOfSpeedBonuses = new SpeedStat (0);


	public EnduranceStat Endurance 
	{		
		get {return (EnduranceStat) NumberOfEnduranceBonuses.AddValues (_Breed.BaseEndurance);}
	}

	public AttackStat Attack 
	{		
		get {return (AttackStat) NumberOfAttackBonuses.AddValues (_Breed.BaseAttack);}
	}

	public DefenseStat Defense 
	{		
		get {return (DefenseStat) NumberOfDefenseBonuses.AddValues (_Breed.BaseDefense);}
	}
		
	public SpecialAttackStat SpecialAttack 
	{		
		get {return (SpecialAttackStat) NumberOfSpecialAttackBonuses.AddValues (_Breed.BaseSpecialAttack);}
	}

	public SpecialDefenseStat SpecialDefense 
	{		
		get {return (SpecialDefenseStat) NumberOfSpecialDefenseBonuses.AddValues (_Breed.BaseSpecialDefense);}
	}

	public SpeedStat Speed 
	{		
		get {return (SpeedStat) NumberOfSpeedBonuses.AddValues (_Breed.BaseSpeed);}
	}

	public int MaxHP 
	{		
		get {return ((Endurance.RawValue + Defense.RoundedValue) * 2);}
	}

	public int MaxStrain 
	{		
		get {return ((Endurance.RawValue + SpecialDefense.RoundedValue) * 2);}
	}

	public string HeldItem = "";

	public ElementTypes Type1
	{
		get 
		{
//			Debug.Log (_Breed.Type1); 
			return _Breed.Type1;
		}
	}
	public ElementTypes Type2
	{
		get 
		{
//			Debug.Log (_Breed.Type2);
			return _Breed.Type2;
		}
	}

	public Pokemon (Pokemon.Breed breed)
	{
		_Breed = breed;
	}
		
	public Pokemon ()
		{
		_Breed = new Breed (ElementTypes.Nothing, ElementTypes.Nothing);
		}

	public void MaturityIncrease ()
	{
		Maturity = ((Level * 2) / Rate);
	}

	public void LevelUp ()
	{
		if (XP >= 2) 
		{
			Level++;
			XP -= 2;
			MaturityIncrease ();
		}
	}

	public void GainEnduranceBonus ()

	{
		NumberOfEnduranceBonuses.RawValue++;
	}



	public class Breed 
	{
		public ElementTypes Type1 = ElementTypes.Nothing;
		public ElementTypes Type2 = ElementTypes.Nothing;

		public EnduranceStat BaseEndurance = new EnduranceStat (0);
		public AttackStat BaseAttack = new AttackStat (0);
		public DefenseStat BaseDefense = new DefenseStat (0);
		public SpecialAttackStat BaseSpecialAttack = new SpecialAttackStat (0);
		public SpecialDefenseStat BaseSpecialDefense = new SpecialDefenseStat (0);
		public SpeedStat BaseSpeed = new SpeedStat (0);


		public Breed ()
		{
			
		}


		public Breed (ElementTypes type1, ElementTypes type2)
	
		{
			Type1 = type1;
			Type2 = type2;
		}
	}
	}


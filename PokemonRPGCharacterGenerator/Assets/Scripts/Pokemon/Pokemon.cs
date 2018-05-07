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
	private Breed _Breed;

	public ElementTypes Type1
	{
		get 
		{
			Debug.Log (_Breed.Type1); 
			return _Breed.Type1;
		}
	}
	public ElementTypes Type2
	{
		get 
		{
			Debug.Log (_Breed.Type1);
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

	public class Breed 
	{
		public ElementTypes Type1 = ElementTypes.Nothing;
		public ElementTypes Type2 = ElementTypes.Nothing;

		public Breed (ElementTypes type1, ElementTypes type2)
	
		{
			Type1 = type1;
			Type2 = type2;
		}
	}
	}


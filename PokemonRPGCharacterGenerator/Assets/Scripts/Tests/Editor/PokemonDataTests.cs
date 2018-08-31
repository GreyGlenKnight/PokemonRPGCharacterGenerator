using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;
using NUnit.Framework;
using NSubstitute;


public class PokemonDataTests

{
	[Test]
	public void CanCreatePokemon ()
	{
		Pokemon TestMon = A.Pokemon ().W_XP(4).W(new Pokemon.Breed(ElementTypes.Fire, ElementTypes.Nothing));
		UnityEngine.Debug.Assert (TestMon != null);
	}

	[Test]
	public void PokemonHasLevel ()
	{
		Pokemon TestMon = A.Pokemon ().W_XP(4).W(new Pokemon.Breed(ElementTypes.Fire, ElementTypes.Nothing));
		UnityEngine.Debug.Assert (TestMon.Level == 0);
	}

	[Test]
	public void PokemonHasElementType1 ()
	{
		Pokemon TestMon = A.Pokemon ().W_XP(4).W(new Pokemon.Breed(ElementTypes.Fire, ElementTypes.Nothing));
		UnityEngine.Debug.Assert (TestMon.Type1 == ElementTypes.Fire);
	}

	[Test]
	public void PokemonHasElementType2 ()
	{
		Pokemon TestMon = A.Pokemon ().W_XP(4).W(new Pokemon.Breed(ElementTypes.Fire, ElementTypes.Flying));
		UnityEngine.Debug.Assert (TestMon.Type2 == ElementTypes.Flying);
	}

	[Test]
	public void PokemonShowsType1OfBreed ()
	{
		Pokemon.Breed TestBreed = new Pokemon.Breed (ElementTypes.Fire, ElementTypes.Fire);
		Pokemon TestMon = A.Pokemon().W(TestBreed);
		UnityEngine.Debug.Assert (TestMon.Type1 == ElementTypes.Fire);
	}

	[Test]
	public void PokemonShowsType2OfBreed ()
	{
		Pokemon.Breed TestBreed = new Pokemon.Breed (ElementTypes.Fire, ElementTypes.Fire);
		Pokemon TestMon = new Pokemon (TestBreed);
		UnityEngine.Debug.Assert (TestMon.Type2 == ElementTypes.Fire);
	}

	[Test]
	public void HasXP ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon.XP == 0);
	}

	[Test]
	public void HasMaturity ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon.Maturity == 0);
	}

	[Test]
	public void HasRate ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon.Rate == 0);
	}

//	[Test]
//	public void PokemonCanLevelUp ()
//	{
//		Pokemon TestMon = A.Pokemon().W_XP(2).W_Rate(5);
//		TestMon.Level = 0;
//		TestMon.Maturity = 0;
////		TestMon.ApplyMaturityBonus (MaturityStatic.GetMaturityBonuses (TestMon.Maturity), TestMon.Maturity);
//
//		TestMon.LevelUp (new LevelUpBonus());
//		UnityEngine.Debug.Assert (TestMon.Level == 1);
//	}

//	[Test]
//	public void Requires2XPToLevelUp ()
//	{
//		Pokemon TestMon = new Pokemon ();
//		TestMon.XP = 0;
//		UnityEngine.Debug.Assert(XPManager.SpendXP () == false);
//	}

//	[Test]
//	public void XPReducedBy2OnLevelUp ()
//	{
//		Pokemon TestMon = A.Pokemon().W_XP(2).W_Rate(5);
//		TestMon.Level = 0;
//		TestMon.XP = 2;
//		UnityEngine.Debug.Assert (TestMon.XP = 0);
//	}

//	[Test]
//	public void WhenLevelIncreasesMaturityChanges ()
//	{
//		Pokemon TestMon = new Pokemon ();
//		TestMon.Rate = 1;
//		TestMon.XP = 2;
//		TestMon.LevelUp (new LevelUpBonus());
//		UnityEngine.Debug.Assert (TestMon.Maturity != 0);
//	}

	[Test]
	public void MaturityChangesBasedOnRate ()
	{
		Pokemon TestMon = new Pokemon ();
		TestMon.Maturity = 0;
		TestMon.Rate = 4;
		TestMon.Level = 4;
		TestMon.MaturityIncrease ();
		UnityEngine.Debug.Assert (TestMon.Maturity == 2);
	}


	[Test]
	public void MaturityContinuesToChangeBasedOnRate ()
	{
		Pokemon TestMon = new Pokemon ();
		TestMon.Maturity = 0;
		TestMon.Rate = 4;
		TestMon.Level = 8;
		TestMon.MaturityIncrease ();
		UnityEngine.Debug.Assert (TestMon.Maturity == 4);
	}


	[Test]
	public void PokemonHasEndurance ()
	{

		Pokemon.Breed TestBreed = A.Breed ().W_Endurance(1);
//		Debug.Log (TestBreed.BaseEndurance.RawValue);

		Pokemon TestMon = new Pokemon (TestBreed);
//		Debug.Log (TestMon.Endurance.RawValue);

		UnityEngine.Debug.Assert (TestMon._StatBlock.Endurance.ThisRawValue > 0);
	}

//	[Test]
//	public void PokemonCalculatesEndurance ()
//	{
//		Pokemon.Breed TestBreed = A.Breed ().W_Endurance(1);
//		Pokemon TestMon = new Pokemon (TestBreed);
//		TestMon.GainEnduranceBonus ();
//		UnityEngine.Debug.Assert (TestMon.Endurance > 1);
//	}

	[Test]
	public void PokemonHasHP ()
	{		
		Pokemon.Breed TestBreed = A.Breed ().W_Endurance(1);
		Pokemon TestMon = new Pokemon (TestBreed);
		UnityEngine.Debug.Assert (TestMon._StatBlock.MaxHP >= 2);
	}

	[Test]
	public void PokemonHasStrain ()
	{
		Pokemon.Breed TestBreed = A.Breed ().W_Endurance(1);
		Pokemon TestMon = new Pokemon (TestBreed);
		UnityEngine.Debug.Assert (TestMon._StatBlock.MaxStrain >= 2);
	}
//
//	[Test]
//	public void PokemonCalculatesHP ()
//	{
//		Pokemon.Breed TestBreed = A.Breed ().W_Endurance(1);
//		Pokemon TestMon = new Pokemon (TestBreed);
//		TestMon.GainEnduranceBonus ();
//		UnityEngine.Debug.Assert (TestMon.MaxHP == 4);
//	}
//
//	[Test]
//	public void PokemonCalculatesStrain ()
//	{
//		Pokemon.Breed TestBreed = A.Breed ().W_Endurance(1);
//		Pokemon TestMon = new Pokemon (TestBreed);
//		TestMon.GainEnduranceBonus ();
//		UnityEngine.Debug.Assert (TestMon.MaxStrain == 4);
//	}

	[Test]
	public void PokemonHasAttack ()
	{
		Pokemon TestMon = new Pokemon ();
        UnityEngine.Debug.Assert (TestMon._StatBlock.Attack.ThisRawValue == 0);
	}

	[Test]
	public void PokemonHasDefense ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon._StatBlock.Defense.ThisRawValue == 0);
	}

	[Test]
	public void PokemonHasSpecialAttack ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon._StatBlock.SpecialAttack.ThisRawValue == 0);
	}

	[Test]
	public void PokemonHasSpecialDefense ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon._StatBlock.SpecialDefense.ThisRawValue == 0);
	}

	[Test]
	public void PokemonHasSpeed ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon._StatBlock.Speed.ThisRawValue == 0);
	}

	[Test]
	public void PokemonHasHeldItem ()
	{
		Pokemon TestMon = A.Pokemon ().W_XP(4).W(new Pokemon.Breed(ElementTypes.Fire, ElementTypes.Nothing));
		UnityEngine.Debug.Assert (TestMon.HeldItem == "");
	}

	[Test]
	public void BreedBuildsMonotype ()
	{
		Pokemon.Breed TestBreed = A.Breed ().W_Type1(ElementTypes.Fire);
//		Debug.Log (TestBreed.Type1);
//		Debug.Log (TestBreed.Type2);
		UnityEngine.Debug.Assert (TestBreed.Type1 == ElementTypes.Fire);
		UnityEngine.Debug.Assert (TestBreed.Type2 == ElementTypes.Nothing);
	}

	[Test]
	public void BreedBuildsDualtype ()
	{
		Pokemon.Breed TestBreed = A.Breed ().W_Types(ElementTypes.Fire, ElementTypes.Flying);
//		Debug.Log (TestBreed.Type1);
//		Debug.Log (TestBreed.Type2);
//		Debug.Log (TestBreed.BaseAttack);
		UnityEngine.Debug.Assert (TestBreed.Type1 == ElementTypes.Fire);
		UnityEngine.Debug.Assert (TestBreed.Type2 == ElementTypes.Flying);
	}



[Test]
public void BreedBuildsDualtype_NSubstitute ()
{
	Pokemon.Breed TestBreed = Substitute.For <Pokemon.Breed>();
		TestBreed.Type1.Returns (ElementTypes.Fire);
		TestBreed.Type2.Returns (ElementTypes.Flying);
//	Debug.Log (TestBreed.Type1);
//	Debug.Log (TestBreed.Type2);
	UnityEngine.Debug.Assert (TestBreed.Type1 == ElementTypes.Fire);
	UnityEngine.Debug.Assert (TestBreed.Type2 == ElementTypes.Flying);
}









}
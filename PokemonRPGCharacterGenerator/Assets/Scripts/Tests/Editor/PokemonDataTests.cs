using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;
using NUnit.Framework;

public class PokemonDataTests

{
	[Test]
	public void CanCreatePokemon ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon != null);
	}

	[Test]
	public void PokemonHasLevel ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon.Level == 0);
	}

	[Test]
	public void PokemonHasElementType1 ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon.Type1 == ElementTypes.Nothing);
	}

	[Test]
	public void PokemonHasElementType2 ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon.Type2 == ElementTypes.Nothing);
	}

	[Test]
	public void PokemonShowsType1OfBreed ()
	{
		Pokemon.Breed TestBreed = new Pokemon.Breed (ElementTypes.Fire, ElementTypes.Fire);
		Pokemon TestMon = new Pokemon (TestBreed);
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

	[Test]
	public void PokemonCanLevelUp ()
	{
		Pokemon TestMon = new Pokemon ();
		TestMon.Rate = 3;
		TestMon.XP = 2;
		TestMon.LevelUp ();
		UnityEngine.Debug.Assert (TestMon.Level == 1);
	}

	[Test]
	public void Requires2XPToLevelUp ()
	{
		Pokemon TestMon = new Pokemon ();
		TestMon.LevelUp ();
		UnityEngine.Debug.Assert (TestMon.Level == 0);
	}

	[Test]
	public void XPReducedBy2OnLevelUp ()
	{
		Pokemon TestMon = new Pokemon ();
		TestMon.Rate = 3;
		TestMon.XP = 2;
		TestMon.LevelUp ();
		UnityEngine.Debug.Assert (TestMon.XP == 0);
	}

	[Test]
	public void WhenLevelIncreasesMaturityChanges ()
	{
		Pokemon TestMon = new Pokemon ();
		TestMon.Rate = 1;
		TestMon.XP = 2;
		TestMon.LevelUp ();
		UnityEngine.Debug.Assert (TestMon.Maturity != 0);
	}

	[Test]
	public void MaturityChangesBasedOnRate ()
	{
		Pokemon TestMon = new Pokemon ();
		TestMon.Rate = 3;
		TestMon.XP = 4;
		for (int i = 0; i < 2; i++) 
		{
			TestMon.LevelUp ();
		}
		UnityEngine.Debug.Assert (TestMon.Maturity == 1);
	}


	[Test]
	public void MaturityContinuesToChangeBasedOnRate ()
	{
		Pokemon TestMon = new Pokemon ();
		TestMon.Rate = 3;
		TestMon.XP = 6;
		for (int i = 0; i < 3; i++) 
		{
			TestMon.LevelUp ();
		}
		UnityEngine.Debug.Assert (TestMon.Maturity == 2);
	}


	[Test]
	public void PokemonHasEndurance ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon.Endurance == 1);
	}

	[Test]
	public void PokemonCalculatesEndurance ()
	{
		Pokemon TestMon = new Pokemon ();
		TestMon.GainEnduranceBonus ();
		UnityEngine.Debug.Assert (TestMon.Endurance > 1);
	}

	[Test]
	public void PokemonHasHP ()
	{
		Pokemon TestMon = new Pokemon ();
		TestMon.RefreshStats ();
		UnityEngine.Debug.Assert (TestMon.HP >= 2);
	}

	[Test]
	public void PokemonHasStrain ()
	{
		Pokemon TestMon = new Pokemon ();
		TestMon.RefreshStats ();
		UnityEngine.Debug.Assert (TestMon.Strain >= 2);
	}

	[Test]
	public void PokemonCalculatesHP ()
	{
		Pokemon TestMon = new Pokemon ();
		TestMon.RefreshStats ();
		UnityEngine.Debug.Assert (TestMon.HP == 4);
	}

	[Test]
	public void PokemonCalculatesStrain ()
	{
		Pokemon TestMon = new Pokemon ();
		TestMon.RefreshStats ();
		UnityEngine.Debug.Assert (TestMon.Strain == 4);
	}

	[Test]
	public void PokemonHasAttack ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon.Attack == 0);
	}

	[Test]
	public void PokemonHasDefense ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon.Defense == 0);
	}

	[Test]
	public void PokemonHasSpecialAttack ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon.SpecialAttack == 0);
	}

	[Test]
	public void PokemonHasSpecialDefense ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon.SpecialDefense == 0);
	}

	[Test]
	public void PokemonHasSpeed ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon.Speed == 0);
	}

	[Test]
	public void PokemonHasHeldItem ()
	{
		Pokemon TestMon = new Pokemon ();
		UnityEngine.Debug.Assert (TestMon.HeldItem == "");
	}

}

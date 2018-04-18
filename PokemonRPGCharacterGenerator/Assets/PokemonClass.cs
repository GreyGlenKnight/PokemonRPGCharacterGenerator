using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonClass 
{
	public int Maturity;
	public int Level;

	public void LevelUp ()
	{
//		Debug.Log ("Gained LevelUp");
//		GainMaturity ()
//		{}
		Level++;
	}

	public void GainNatureBonus ()
	{
		Debug.Log ("Gained Nature :"+Maturity);
	}

	public void GainSTABBonus ()
	{
		Debug.Log ("Gained STAB :"+Maturity);
	}

	public void ApplyMaturityBonus (MaturityBonus MBonus, int maturity)
	{
		Maturity = maturity;
		if (MBonus == null) 
		{
			return;
		}
			MBonus.ApplyBonus (this);	
	}

	public PokemonClass ()
	{
		Level = 0;
	}

}
